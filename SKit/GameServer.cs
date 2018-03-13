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
        public string Id { get; }
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

        private Dictionary<string, GameProtocolProcessMethod> _Handlers = new Dictionary<string, GameProtocolProcessMethod>();
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
        public async void Start()
        {
            //反射
            this.ReflectProtocols();

            if (!IsRunning)
            {
                IsRunning = true;

                //启动任务工作线程
                _workingTaskTokenSource = new CancellationTokenSource();
                _workingTask = new Task(Loop, _workingTaskTokenSource.Token);
                _workingTask.Start();

                //启动发送线程
                _sendingTaskTokenSource = new CancellationTokenSource();
                _sendingTask = new Task(SendingLoop, _sendingTaskTokenSource.Token);
                _sendingTask.Start();


                //启动接收线程
                _listenerTokenSource = new CancellationTokenSource();
                _logger.LogInformation($"Game Server [{Id}] Starting...");
                var threads = Process.GetCurrentProcess().Threads;
                _listener.Start();
                while (!_listenerTokenSource.IsCancellationRequested)
                {
                    var socket = await _listener.AcceptSocketAsync();
                    var args = _socketRecvArgsPool.Pop();
                    var session = new GameSession();
                    session.Server = this;
                    session.Socket = socket;
                    session.SocketAsyncEventArgs = args;
                    args.UserToken = session;

                    _sessions.TryAdd(session.Id, session);
                    this.OnNewSessionConnected(session);

                    _logger.LogInformation($"New client entered [{session.Id}]");

                    bool willRaiseEvent = socket.ReceiveAsync(args);
                    if (!willRaiseEvent)
                    {
                        ProcessReceive(args);
                    }
                }
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                _logger.LogInformation($"Game Server [{Id}] Closing...");
                _listenerTokenSource.Cancel();
                _workingTaskTokenSource.Cancel();
                _sendingTaskTokenSource.Cancel();
                Task.WaitAll(_workingTask, _sendingTask);
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
            if (session.IsAuthorized)
            {
                _users.AddOrUpdate(session.UserName, session, (username, oldSession) =>
                {
                    //把原来的玩家踢下线
                    oldSession.Logout();
                    CloseClientSocket(oldSession.SocketAsyncEventArgs, ClientCloseReason.KickOut);
                    return session;
                });
            }
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

        #region 网络部分
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
                try
                {
                    var datas = Resolve(session, e);
                    foreach (ArraySegment<byte> data in datas)
                    {
                        //消息处理: 反序列化和筛选
                        if (!DigestRecevedData(session, data))
                        {
                            CloseClientSocket(e, ClientCloseReason.ProtocolError);
                            return;
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
            catch (Exception) { }
            token.Socket.Close();

            if (token.IsAuthorized)
            {
                _users.TryRemove(token.UserName, out token);
            }

            if (_sessions.TryRemove(token.Id, out token))
            {
                //任务队列加入玩家离线
                foreach (GameController controller in _controllers.Values)
                {
                    _workingQueue.Enqueue(new GamePlayerLeaveTask(token, controller, reason));
                }
                this.OnSessionClosed(token);
            }
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
        private void SendingLoop()
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
                                        GameSession session;
                                        if (_sessions.TryGetValue(message.DestId, out session))
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
                                        GameSession session;
                                        if (_users.TryGetValue(message.DestId, out session))
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

        private void Loop()
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
                            task.DoAction();
                        }
                    }
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
        /// <param name="session"></param>
        /// <param name="data"></param>
        protected bool DigestRecevedData(GameSession session, ArraySegment<byte> data)
        {
            string cmd = _serializer.DataToCmd(data.Array, data.Offset, data.Count);
            if (!this._Handlers.ContainsKey(cmd))
            {
                //如果没有处理器，先刷掉一批
                return false;
            }
            var handler = this._Handlers[cmd];
            var type = handler.RequestType;
            var request = _serializer.Deserialize(type, data.Array, data.Offset, data.Count);
            var task = new GameTask(handler.ProcessAction, session, request, handler.Controller);
            this._workingQueue.Enqueue(task);
            return true;
        }
        #endregion

        #region 通讯协议约定
        class GameProtocolProcessMethod
        {
            public String CMD { get; set; }
            public Delegate ProcessAction { get; set; }
            public Type RequestType { get; set; }
            public MethodInfo MethodInfo { get; set; }
            public GameController Controller { get; set; }
        }

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
                _controllers.Add(type, controller);
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public|BindingFlags.DeclaredOnly|BindingFlags.Instance);
                foreach (var methodInfo in methods)
                {
                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    if (parameterInfos.Length == 2)
                    {
                        Type requestType = parameterInfos[1].ParameterType;
                        String cmd = requestType.Name;
                        Type[] templateTypeSet = new[] { typeof(GameSession), requestType };
                        Type methodGenericType = typeof(Action<,>);
                        Type methodType = methodGenericType.MakeGenericType(templateTypeSet);
                        Delegate actionMethod = Delegate.CreateDelegate(methodType, controller, methodInfo);
                        var handler = new GameProtocolProcessMethod()
                        {
                            CMD = cmd,
                            MethodInfo = methodInfo,
                            ProcessAction = actionMethod,
                            RequestType = requestType,
                            Controller = controller
                        };
                        _Handlers.Add(handler.CMD, handler);
                        _serializer.Register(requestType);
                    }

                }
            }
        }

        #endregion 
    }
}
