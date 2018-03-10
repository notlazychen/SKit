using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SKit.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SKit
{
    /// <summary>
    /// 
    /// </summary>
    public class GameServer : IDisposable
    {
        public string Id { get; }
        public bool IsRunning { get; private set; }

        //private Task _listenerTask;
        private CancellationTokenSource _listenerTokenSource;

        private ElasticPool<SocketAsyncEventArgs> _socketArgsPool;//输入缓冲池
        private ISPackager _packager;//拆包打包器
        private SKitConfig _config;//配置


        /// <summary>
        /// 核心监听客户端TCP
        /// </summary>
        private TcpListener _listener;
        private readonly ILogger<GameServer> _logger;

        public GameServer(ILogger<GameServer> logger, IOptions<SKitConfig> configProvider, ISPackager packager)
        {
            _logger = logger;
            _packager = packager;
            _config = configProvider.Value;

            _socketArgsPool = new ElasticPool<SocketAsyncEventArgs>(() =>
            {
                var args = new SocketAsyncEventArgs();
                var buff = new byte[_config.BufferSize];
                args.SetBuffer(buff, 0, buff.Length);
                args.Completed += IO_Completed;
                return args;
            });
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, _config.Port);
            _listenerTokenSource = new CancellationTokenSource();
            _listener = new TcpListener(endPoint);
            _listener.AllowNatTraversal(true);
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        public async void Start()
        {
            if (!IsRunning)
            {
                _logger.LogInformation($"Game Server [{Id}] Starting...");
                var threads = Process.GetCurrentProcess().Threads;
                IsRunning = true;
                _listener.Start();
                //_listenerTask = new Task(async ()=> {
                //    while (!_listenerTokenSource.IsCancellationRequested)
                //    {
                //        Console.WriteLine("task thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                //        var socket = await _listener.AcceptSocketAsync();

                //        //socket.Receive
                //        Thread.Sleep(1000);
                //        Console.WriteLine("sleep thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                //    }
                //}, _listenerTokenSource.Token);
                //_listenerTask.Start();
                while (!_listenerTokenSource.IsCancellationRequested)
                {
                    var socket = await _listener.AcceptSocketAsync();
                    var args = _socketArgsPool.Pop();
                    var session = new GameSession();
                    session.Socket = socket;
                    args.UserToken = session;
                    _logger.LogInformation($"New client entered [{session.Id}]");

                    bool willRaiseEvent = socket.ReceiveAsync(args);
                    if (!willRaiseEvent)
                    {
                        ProcessReceive(args);
                    }
                }
            }
        }

        /// <summary>
        /// 拆包
        /// </summary>
        private IEnumerable<ArraySegment<byte>> Resolve(GameSession session, SocketAsyncEventArgs e)
        {
            int from = 0;
            session.BufferReaderCursor += e.BytesTransferred;//剩余可读取字节
            
            while (true)
            {
                var readlength = 0;
                ArraySegment<byte> data = _packager.UnPack(e.Buffer, from, session.BufferReaderCursor, ref readlength);
                if (readlength != 0)
                {
                    yield return data;
                    session.BufferReaderCursor -= readlength;
                    from += readlength;
                    continue;
                }
                break;
            }
            if (session.BufferReaderCursor > 0)
            {
                Buffer.BlockCopy(e.Buffer, from, e.Buffer, 0, session.BufferReaderCursor);
            }
            e.SetBuffer(session.BufferReaderCursor, e.Buffer.Length - session.BufferReaderCursor);
        }

        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            // check if the remote host closed the connection
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                GameSession session = (GameSession)e.UserToken;
                Debug.Assert(session != null, "session != null");
                var datas = Resolve(session, e);
                foreach (ArraySegment<byte> data in datas)
                {
                    OnMessageReceiving(session, data);
                }
                //PostReceive(receiveEventArgs);    
                bool willRaiseEvent = session.Socket.ReceiveAsync(e);
                if (!willRaiseEvent)
                {
                    ProcessReceive(e);
                }
            }
            else
            {
                CloseClientSocket(e);
            }
        }

        private void ProcessSend(SocketAsyncEventArgs e)
        {

        }

        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            GameSession token = e.UserToken as GameSession;
            // close the socket associated with the client
            try
            {
                token.Socket.Shutdown(SocketShutdown.Send);
            }
            // throws if client process has already closed
            catch (Exception) { }
            token.Socket.Close();

            // Free the SocketAsyncEventArg so they can be reused by another client
            _socketArgsPool.Push(e);
        }

        private void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }
        }

        /// <summary>
        /// 刚接受到消息还未放入处理队列之前，可重写此处做筛选
        /// </summary>
        /// <param name="session"></param>
        /// <param name="data"></param>
        protected virtual void OnMessageReceiving(GameSession session, ArraySegment<byte> data)
        {
            string msg = Encoding.UTF8.GetString(data.Array, data.Offset, data.Count);
            _logger.LogInformation($"{session.Id} : {msg}");
        }

        public void Stop()
        {
            if (IsRunning)
            {
                _listenerTokenSource.Cancel();
                //Task.WaitAll(_listenerTask);
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
