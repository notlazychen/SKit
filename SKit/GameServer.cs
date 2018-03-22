using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SKit.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SKit
{
    /// <summary>
    /// 游戏服务器
    /// </summary>
    public class GameServer : IDisposable
    {
        public int Id { get; }
        public bool IsRunning { get; private set; }
        /// <summary>
        /// 监听端口
        /// </summary>
        public int Port { get { return Config.Port; } }
        /// <summary>
        /// 在线人数
        /// </summary>
        public int ClientCount { get { return _sessions.Count; } }
        /// <summary>
        /// 登录玩家数
        /// </summary>
        public int UserCount { get { return _users.Count; } }

        private ConcurrentQueue<GameTask> _workingQueue = new ConcurrentQueue<GameTask>();
        private Task _workingTask;
        private CancellationTokenSource _workingTaskTokenSource;

        private CancellationTokenSource _listenerTokenSource;
        private Task _listenerTask;

        private ConcurrentQueue<GameMessage> _sendingQueue = new ConcurrentQueue<GameMessage>();
        private Task _sendingTask;
        private CancellationTokenSource _sendingTaskTokenSource;


        private ElasticPool<SocketAsyncEventArgs> _socketRecvArgsPool;//输入缓冲池
        private ElasticPool<SocketAsyncEventArgs> _socketSendArgsPool;//输出缓冲池
        private Packager _packager;//拆包打包器
        private Serializer _serializer;//正反序列化工具
        private SKitConfig Config { get; }//配置
        private IServiceCollection _services;//DI容器

        #region 连接管理
        private ConcurrentDictionary<string, GameSession> _sessions = new ConcurrentDictionary<string, GameSession>();//所有连接 Key:SessionId
        private ConcurrentDictionary<string, GameSession> _users = new ConcurrentDictionary<string, GameSession>();//登录的连接 Key:UserName
        #endregion

        private Dictionary<string, GameProtocolProcessHandler> _Handlers = new Dictionary<string, GameProtocolProcessHandler>();
        private Dictionary<Type, GameController> _controllers = new Dictionary<Type, GameController>();

        /// <summary>
        /// 核心监听客户端TCP
        /// </summary>
        private TcpListener _listener;
        private readonly ILogger<GameServer> _logger;

        #region 开放方法
        public GameServer(IServiceCollection services)
        {
            _services = services;
            var provicer = services.BuildServiceProvider();
            Config = provicer.GetService<IOptions<SKitConfig>>().Value;
            Debug.Assert(Config != null, "SKitConfig Can't be NULL!");
            _serializer = provicer.GetService<Serializer>();
            Debug.Assert(_serializer != null, "ISerializable Can't be NULL!");
            _logger = provicer.GetService<ILogger<GameServer>>();
            Debug.Assert(_logger != null, "ILogger Can't be NULL!");
            _packager = provicer.GetService<Packager>();
            Debug.Assert(_packager != null, "ISPackager Can't be NULL!");
            this.Id = Config.Id;

            _socketRecvArgsPool = new ElasticPool<SocketAsyncEventArgs>(() =>
            {
                var args = new SocketAsyncEventArgs();
                var buff = new byte[Config.RecvBufferSize];
                args.SetBuffer(buff, 0, buff.Length);
                args.Completed += IO_Completed;
                return args;
            }, Config.PresetUserCount);
            _socketSendArgsPool = new ElasticPool<SocketAsyncEventArgs>(() =>
            {
                var args = new SocketAsyncEventArgs();
                var buff = new byte[Config.SendBufferSize];
                args.SetBuffer(buff, 0, buff.Length);
                args.Completed += IO_Completed;
                return args;
            }, Config.PresetUserCount);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Config.Port);
            _listener = new TcpListener(endPoint);
            //_listener.AllowNatTraversal(true);
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        public void Start()
        {
            //反射
            this.ReflectProtocols();

            if (!IsRunning)
            {
                _logger.LogInformation($"Game Server [{Id}] Starting...");
                IsRunning = true;

                //启动任务工作线程
                _workingTaskTokenSource = new CancellationTokenSource();
                _workingTask = new Task(LoopWorking, _workingTaskTokenSource.Token);
                _workingTask.Start();

                //启动发送线程
                _sendingTaskTokenSource = new CancellationTokenSource();
                _sendingTask = new Task(LoopSending, _sendingTaskTokenSource.Token);
                _sendingTask.Start();


                //启动接收线程
                _listenerTokenSource = new CancellationTokenSource();
                _listenerTask = new Task(() =>
                {
                    while (!_listenerTokenSource.IsCancellationRequested)
                    {
                        try
                        {
                            var socket = _listener.AcceptSocket();
                            var args = _socketRecvArgsPool.Pop();
                            var session = new GameSession
                            {
                                Server = this,
                                Socket = socket,
                                SocketAsyncEventArgs = args
                            };
                            args.UserToken = session;

                            _sessions.TryAdd(session.Id, session);
                            this.OnNewSessionConnected(session);

                            _logger.LogDebug($"{session.Id}: Enter");

                            bool willRaiseEvent = socket.ReceiveAsync(args);
                            if (!willRaiseEvent)
                            {
                                ProcessReceive(args);
                            }
                        }
                        catch (SocketException)
                        {
                            //ignore
                        }
                        Thread.Sleep(1);
                    }
                }, _listenerTokenSource.Token);
                _listener.Start();
                _listenerTask.Start();
                _logger.LogInformation($"Game Server [{Id}] Started");

            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                _logger.LogInformation($"Game Server [{Id}] Closing...");
                _listenerTokenSource.Cancel();
                _sendingTaskTokenSource.Cancel();
                _workingTaskTokenSource.Cancel();

                _listener.Stop();

                Task.WaitAll(_listenerTask, _workingTask, _sendingTask);
                IsRunning = false;
                _logger.LogInformation($"Game Server [{Id}] Closed");
            }
        }

        public void Dispose()
        {
            Stop();
        }

        internal void SetLogin(GameSession session)
        {
            _users.AddOrUpdate(session.UserId, session, (username, oldSession) =>
            {
                    //把原来的玩家踢下线
                    oldSession.Logout();
                CloseClientSocket(oldSession.SocketAsyncEventArgs, ClientCloseReason.Displacement);
                return session;
            });
        }

        /// <summary>
        /// 群发给所有连接
        /// </summary>
        public void BroadcastAllSessionAsync(Object msg)
        {
            GameMessage gmsg = new GameMessage()
            {
                MessageType = MessageType.AllSession,
                Msg = msg,
            };
            _sendingQueue.Enqueue(gmsg);
        }
        /// <summary>
        /// 群发给所有登录用户
        /// </summary>
        public void BroadcastAllUserAsync(Object msg)
        {
            GameMessage gmsg = new GameMessage()
            {
                MessageType = MessageType.AllUser,
                Msg = msg,
            };
            _sendingQueue.Enqueue(gmsg);
        }
        /// <summary>
        /// 发送给指定登录用户
        /// </summary>
        public void SendByUserNameAsync(string username, Object msg)
        {
            GameMessage gmsg = new GameMessage()
            {
                MessageType = MessageType.ToUser,
                Msg = msg,
                DestId = username
            };
            _sendingQueue.Enqueue(gmsg);
        }
        /// <summary>
        /// 发送给指定连接
        /// </summary>
        public void SendBySessionIdAsync(string sessionId, Object msg)
        {
            GameMessage gmsg = new GameMessage()
            {
                MessageType = MessageType.ToSession,
                Msg = msg,
                DestId = sessionId
            };
            _sendingQueue.Enqueue(gmsg);
        }
        #endregion

        /// <summary>
        /// 有新的连接建立
        /// </summary>
        /// <param name="session"></param>
        /// <remarks>这里是网络通信部分，与游戏逻辑处理不是同一线程</remarks>
        protected virtual void OnNewSessionConnected(GameSession session)
        {

        }
        /// <summary>
        /// 连接断开
        /// </summary>
        protected virtual void OnSessionClosed(GameSession session)
        {

        }

        /// <summary>
        /// 接收消息前，可用于重写Filter
        /// </summary>
        /// <returns>是否过滤掉</returns>
        protected virtual bool Filter(GameSession session, GameProtocolProcessHandler handler)
        {
            if (!handler.AllowAnonymous && !session.IsAuthorized)
            {
                return true;
            }
            return false;
        }

        #region 网络部分
        /// <summary>
        /// 拆包
        /// </summary>
        private IEnumerable<ArraySegment<byte>> Resolve(GameSession session, SocketAsyncEventArgs e)
        {
            int from = 0;
            session.BufferReaderCursor += e.BytesTransferred;//剩余可读取字节

            while (session.BufferReaderCursor > 0)
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
                try
                {
                    var datas = Resolve(session, e);
                    foreach (ArraySegment<byte> data in datas)
                    {
                        //消息处理: 反序列化和筛选
                        if (!DigestRecevedData(session, data))
                        {
                            if (Config.KickoutWhenProtocolError)
                            {
                                CloseClientSocket(e, ClientCloseReason.ProtocolError);
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    CloseClientSocket(e, ClientCloseReason.ReceiveDataError);
                    return;
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
                CloseClientSocket(e, ClientCloseReason.ClientClose);
            }
        }

        private void CloseClientSocket(SocketAsyncEventArgs e, ClientCloseReason reason)
        {
            GameSession token = e.UserToken as GameSession;
            // close the socket associated with the client
            try
            {
                token.Socket.Shutdown(SocketShutdown.Send);
            }
            // throws if client process has already closed
            catch (Exception)
            {
                // ignored
            }

            token.Socket.Close();

            var task = new GamePlayerLeaveTask(token, reason, _controllers.Values);
            if (reason == ClientCloseReason.Displacement)
            {
                try
                {
                    task.DoAction();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
            else
            {
                //任务队列加入玩家离线
                _workingQueue.Enqueue(task);
                if (token.IsAuthorized)
                {
                    _users.TryRemove(token.UserId, out _);
                }
            }

            this.OnSessionClosed(token);
            _sessions.TryRemove(token.Id, out _);
            token?.Dispose();
            // Free the SocketAsyncEventArg so they can be reused by another client
            _socketRecvArgsPool.Push(e);
            _logger.LogDebug($"{token.Id}: LEAVE, reason: {reason}");
        }

        private void ProcessSend(SocketAsyncEventArgs e)
        {
            _socketSendArgsPool.Push(e);
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
        #endregion

        #region 任务执行派发部分
        private void LoopSending()
        {
            while (!_sendingTaskTokenSource.IsCancellationRequested)
            {
                try
                {
                    if (!_sendingQueue.IsEmpty)
                    {
                        GameMessage message = null;
                        if (_sendingQueue.TryDequeue(out message))
                        {
                            var args = _socketSendArgsPool.Pop();
                            //string cmd = _serializer.EntityToCmd(message.Msg);
                            byte[] data = _serializer.Serialize(message.Msg);
                            ArraySegment<byte> encodedMessage = _packager.Pack(data, args.Buffer, 0, args.Buffer.Length);
                            args.SetBuffer(0, encodedMessage.Count);
                            switch (message.MessageType)
                            {
                                case MessageType.AllSession:
                                    foreach (var session in _sessions.Values)
                                    {
                                        if (!session.Socket.SendAsync(args))
                                        {
                                            ProcessSend(args);
                                        }
                                    }
                                    break;
                                case MessageType.AllUser:
                                    foreach (var session in _users.Values)
                                    {
                                        if (!session.Socket.SendAsync(args))
                                        {
                                            ProcessSend(args);
                                        }
                                    }
                                    break;
                                case MessageType.ToSession:
                                    {
                                        if (_sessions.TryGetValue(message.DestId, out var session))
                                        {
                                            if (!session.Socket.SendAsync(args))
                                            {
                                                ProcessSend(args);
                                            }
                                        }
                                    }
                                    break;
                                case MessageType.ToUser:
                                    {
                                        if (_users.TryGetValue(message.DestId, out var session))
                                        {
                                            if (!session.Socket.SendAsync(args))
                                            {
                                                ProcessSend(args);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }

        internal GameSession _currentWorkingSession;
        private void LoopWorking()
        {
            while (!_workingTaskTokenSource.IsCancellationRequested)
            {
                try
                {
                    if (!_workingQueue.IsEmpty)
                    {
                        GameTask task = null;
                        if (_workingQueue.TryDequeue(out task))
                        {
                            _currentWorkingSession = task.Session;
                            task.DoAction();
                        }
                    }
                }
                catch (System.Data.Common.DbException ex)
                {
                    //数据库异常，宕机吧
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 处理消息包
        /// </summary>
        /// <returns>是否执行成功</returns>
        protected bool DigestRecevedData(GameSession session, ArraySegment<byte> data)
        {
            string cmd = _serializer.DataToCmd(data.Array, data.Offset, data.Count);
            if (cmd == null || !this._Handlers.ContainsKey(cmd))
            {
                //如果没有处理器，先刷掉一批
                return false;
            }
            var handler = this._Handlers[cmd];
            var type = handler.RequestType;
            if (Filter(session, handler))
            {
                return false;
            }
            var request = _serializer.Deserialize(type, data.Array, data.Offset, data.Count);
            var task = new GameRequestTask(handler.ProcessAction, session, request);
            this._workingQueue.Enqueue(task);
            return true;
        }
        #endregion

        #region 通讯协议约定
        /// <summary>
        /// 获得其他控制器
        /// </summary>
        public T GetController<T>() where T : GameController
        {
            Type t = typeof(T);
            return _controllers[t] as T;
        }
        /// <summary>
        /// 消息驱动，通过消息实体名找处理函数
        /// </summary>
        private void ReflectProtocols()
        {
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(GameController))
                {
                    _services.AddTransient(typeof(GameController), type);
                }
            }

            var provider = _services.BuildServiceProvider();
            var controllers = provider.GetServices<GameController>();
            foreach (var controller in controllers)
            {
                Type type = controller.GetType();
                controller.Server = this;
                _controllers.Add(type, controller);

                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                foreach (var methodInfo in methods)
                {
                    if (methodInfo.IsSpecialName || !methodInfo.Name.StartsWith("Call_"))
                    {
                        continue;
                    }
                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    if (parameterInfos.Length == 1)
                    {
                        Type requestType = parameterInfos[0].ParameterType;
                        String cmd = requestType.Name;
                        Type[] templateTypeSet = new[] { requestType };
                        Type methodGenericType = typeof(Action<>);
                        Type methodType = methodGenericType.MakeGenericType(templateTypeSet);
                        Delegate actionMethod = Delegate.CreateDelegate(methodType, controller, methodInfo);
                        bool allowanonymous = methodInfo.GetCustomAttribute<AllowAnonymousAttribute>() != null;
                        var handler = new GameProtocolProcessHandler()
                        {
                            CMD = cmd,
                            MethodInfo = methodInfo,
                            ProcessAction = actionMethod,
                            RequestType = requestType,
                            Controller = controller,
                            AllowAnonymous = allowanonymous
                        };
                        GameProtocolProcessHandler oldhandler = null;
                        if (!_Handlers.TryGetValue(handler.CMD, out oldhandler))
                        {
                            _Handlers.Add(handler.CMD, handler);
                            _serializer.Register(requestType);
                        }
                        else
                        {
                            throw new Exception($"Request CMD [{handler.CMD}] in [{handler.Controller.GetType().Name }.{handler.MethodInfo.Name}] already declared in method: [{oldhandler.Controller.GetType().Name }.{oldhandler.MethodInfo.Name}]");
                        }
                    }

                }
            }

            foreach (var controller in controllers)
            {
                controller.RegisterEvents();
            }
        }

        #endregion 
    }
}
