using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Frontline.Common;
using Microsoft.Extensions.Options;
using NetMQ;
using NetMQ.Sockets;
using protocol;
using SKit.Common;
using SKit.Common.Utils;

namespace Frontline.MQ
{
    public delegate void OnReceived(ArraySegment<byte> data);
    public interface IServerSender: IDisposable
    {
        void Send(byte[] data);
    }
    public interface IServerReceiver: IDisposable
    {
        string BindAddress { get; }
        void Close();
        void Receive(OnReceived callback);

        IServerSender MakeSender(string address);
    }

    public class PushAdapter : IServerSender
    {
        private readonly byte[] _buffer = new byte[8];
        private readonly NetMQSocket _socket;

        public PushAdapter(string address)
        {
            _socket = new PushSocket();
            _socket.Connect(address);
        }

        public void Dispose()
        {
            _socket.Dispose();
        }

        public void Send(byte[] data)
        {
            _socket.SendFrame(data);
        }
    }

    public class PullAdapter : IServerReceiver, IDisposable
    {
        private readonly NetMQSocket _rep;
        private OnReceived onReceived;
        private string _bindAddress;

        public PullAdapter(string bindAddress)
        {
            _bindAddress = bindAddress;
            _rep = new PullSocket();
            
            _rep.Bind(bindAddress);            
        }

        public string BindAddress
        {
            get { return _bindAddress; }
        }

        public void Close()
        {
            _rep.Unbind(BindAddress);
            _rep.Dispose();
        }

        public void Receive(OnReceived callback)
        {
            if (onReceived == null)
            {
                onReceived = callback;
            }
            var buff = _rep.ReceiveFrameBytes();
            
            onReceived?.Invoke(new ArraySegment<byte>(buff, 0, buff.Length));
        }

        public IServerSender MakeSender(string address)
        {
            var sender = new PushAdapter(address);
            return sender;
        }

        public void Dispose()
        {
            this.Close();
        }
    }

    public abstract class ServerBase : IDisposable
    {
        protected virtual int MaxProcessCount
        {
            get { return 6; }
        }

        private static byte[] _xorbytes;
        private IServerReceiver _receiverAdapter;
        private readonly ConcurrentDictionary<string, ServerSession> _sessions = new ConcurrentDictionary<string, ServerSession>();

        protected readonly ModuleManager CommandManager;

        public string LocalAddress { get; private set; }

        private Thread _mainThread;
        private CancellationTokenSource _mainThreadToken;

        public event EventHandler<Exception> CatchUnhandledException;
        public event EventHandler<ServerMessageReceivedEventArgs> ServerMessageReceived;
        public event EventHandler<RelayMessageReceivedEventArgs> RelayMessageReceived;

        public ServerBase(bool refallModule = true)
        {
            CommandManager = new ModuleManager();
            if (refallModule)
            {
                CommandManager.ReflectInitialize();
            }
        }

        public void Start(IServerReceiver recvAdapter, string secret)
        {
            _xorbytes = Encoding.UTF8.GetBytes(secret);
            _receiverAdapter = recvAdapter;
            LocalAddress = _receiverAdapter.BindAddress;
            _mainThreadToken = new CancellationTokenSource();
            _mainThread = new Thread(LoopPulling);
            _mainThread.Start();

            OnStart();
        }

        private void LoopPulling(object state)
        {
            while (!_mainThreadToken.IsCancellationRequested)
            {
                Thread.Sleep(1);
                try
                {
                    _receiverAdapter.Receive((buf) =>
                    {
                        int offset = 0;
                        byte act = buf.Array[offset];
                        offset += 1;
                        if (act == 0)
                        {
                            short cmd = MathUtils.ToShort(buf.Array, offset);
                            offset += 2;
                            int pidCount = buf.Array[offset];
                            offset += 1;
                            String[] pids = new String[pidCount];
                            offset += ParsePids(buf.Array, offset, pids);
                            int bodyLength = buf.Array.Length - offset;

                            var head = Varint.Int2ByteArray(bodyLength + 2);
                            byte[] content = new byte[bodyLength + 2 + head.Count];
                            Array.Copy(head.Array, head.Offset, content, 0, head.Count);//先拷贝头
                                Array.Copy(buf.Array, 1, content, head.Count, 2);//先拷贝cmd

                                MathUtils.Xor(buf.Array, offset, bodyLength, _xorbytes);
                            Array.Copy(buf.Array, offset, content, head.Count + 2, bodyLength);//再拷贝实体
                                if (RelayMessageReceived != null)
                            {
                                RelayMessageReceived.Invoke(this, new RelayMessageReceivedEventArgs() { Receivers = pids, Data = content });
                            }
                        }
                        else
                        {
                            string address = Encoding.UTF8.GetString(buf.Array, offset, 30);
                            offset += 30;
                            ServerMessageInfo requestInfo = CommandManager.Parse(new ArraySegment<byte>(buf.Array, offset, buf.Count - offset));
                            requestInfo.Address = address;
                                //_requestInfos.Enqueue(requestInfo);
                                Console.WriteLine("收到来自{0}的消息", address);
                            ServerSession session;
                            if (!_sessions.TryGetValue(address, out session))
                            {
                                Console.WriteLine("创建对{0}的连接", address);
                                session = Connect(address);
                            }
                            if (ServerMessageReceived != null)
                            {
                                ServerMessageReceived.Invoke(this, new ServerMessageReceivedEventArgs() { ServerSession = session, Entity = requestInfo.Entity });
                            }
                            else
                            {
                                CommandManager.ProcessAction(session, requestInfo);
                            }
                        }
                            ////计划任务
                            //DateTime now = DateTime.Now;
                            //foreach (ModuleBase handler in CommandManager.Modules)
                            //{
                            //    handler.DoLoop(now);
                            //}
                        });
                }
                catch (ObjectDisposedException)
                {
                    //ignore
                }
                catch (SocketException)
                {
                    //OnCatchUnhandledException(ex);
                    //ignore
                }
                catch (NullReferenceException)
                {
                    //ignore
                }
                catch (TerminatingException)
                {
                    //ignore
                }
                catch (Exception ex)
                {
                    OnCatchUnhandledException(ex);
                    continue;
                }
            }
        }

        public void Stop()
        {
            try
            {
                _receiverAdapter.Dispose();
            }
            catch (Exception)
            {
                // ignored
            }
            _mainThreadToken.Cancel();
            NetMQConfig.Cleanup(false);
            foreach (var session in _sessions.Values)
            {
                try
                {
                    session.Socket.Dispose();
                }
                catch (Exception)
                {
                    //ignore
                }
            }
            _sessions.Clear();
            _mainThread.Join();
            OnStop();
        }

        protected virtual void OnStart()
        {

        }
        protected virtual void OnStop()
        {

        }

        public ServerSession Connect(string address)
        {
            var socket = _receiverAdapter.MakeSender(address);
            var session = new ServerSession(address, LocalAddress, socket);
            _sessions.TryAdd(address, session);
            return session;
        }

        public T GetModule<T>() where T : class
        {
            foreach (var module in CommandManager.Modules)
            {
                if (module is T)
                {
                    return module as T;
                }
            }
            throw new Exception(string.Format("No this module class type of {0}", typeof(T).FullName));
        }

        protected virtual void OnCatchUnhandledException(Exception e)
        {
            CatchUnhandledException?.Invoke(this, e);
        }


        private int ParsePids(byte[] data, int offset, String[] pids)
        {
            int read = 0;
            for (int i = 0; i < pids.Length; i++)
            {
                int l = data[offset + read];
                read += 1;
                String pid = Encoding.UTF8.GetString(data, offset + read, l);
                pids[i] = pid;
                read += l;
            }
            return read;
        }

        public void Dispose()
        {
            this.Stop();
        }
    }
}
