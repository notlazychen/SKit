using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SKit.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public const string MainWorldThreadName = "MainWorldThread";
        public int Id { get; }
        public bool IsRunning { get; private set; }
        /// <summary>
        /// 监听端口
        /// </summary>
        public int Port => Config.Port;

        /// <summary>
        /// 在线人数
        /// </summary>
        public int ClientCount => _sessions.Count;

        /// <summary>
        /// 登录玩家数
        /// </summary>
        public int UserCount => _users.Count;

        private readonly ConcurrentQueue<GameTask> _workingQueue = new ConcurrentQueue<GameTask>();
        private Thread _workingTask;
        //private CancellationTokenSource _listenerTokenSource;
        //private CancellationTokenSource _sendingTaskTokenSource;
        private CancellationTokenSource _workingTaskTokenSource;

        private SocketAsyncEventArgs _acceptEventArg;

        //private Task _listenerTask;

        private readonly ConcurrentQueue<GameMessage> _sendingQueue = new ConcurrentQueue<GameMessage>();
        private Thread _sendingTask;


        private readonly ElasticPool<SocketAsyncEventArgs> _socketRecvArgsPool;//输入缓冲池
        private readonly ElasticPool<SocketAsyncEventArgs> _socketSendArgsPool;//输出缓冲池
        private readonly Packager _packager;//拆包打包器
        private readonly Serializer _serializer;//正反序列化工具
        private SKitConfig Config { get; }//配置
        private readonly IServiceCollection _services;//DI容器

        #region 连接管理
        private readonly ConcurrentDictionary<string, GameSession> _sessions = new ConcurrentDictionary<string, GameSession>();//所有连接 Key:SessionId
        private readonly ConcurrentDictionary<string, GameSession> _users = new ConcurrentDictionary<string, GameSession>();//登录的连接 Key:UserName
        #endregion

        private readonly Dictionary<string, GameProtoHandlerInfo> _handlers = new Dictionary<string, GameProtoHandlerInfo>();
        private readonly Dictionary<Type, GameController> _controllers = new Dictionary<Type, GameController>();
        public IEnumerable<GameProtoHandlerInfo> Handlers
        {
            get
            {
                return _handlers.Values;
            }
        }
        /// <summary>
        /// 核心监听客户端TCP
        /// </summary>
        private Socket _listener;
        private readonly ILogger<GameServer> _logger;

        #region 事件
        public event EventHandler<GameTaskDoneEventArgs> GameTaskDone;
        private void OnGameTaskDone(GameTaskDoneEventArgs args)
        {
            GameTaskDone?.Invoke(this, args);
        }
        #endregion

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
                _workingTask = new Thread(LoopWorking);
                _workingTask.Name = MainWorldThreadName;
                _workingTask.Start();

                //启动发送线程
                //_sendingTaskTokenSource = new CancellationTokenSource();
                _sendingTask = new Thread(LoopSending);
                _sendingTask.Start();

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Config.Port);
                _listener = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                _listener.Bind(endPoint);
                _listener.Listen(Config.Backlog);

                _listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                _listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                //_listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);

                SocketAsyncEventArgs acceptEventArg = new SocketAsyncEventArgs();
                _acceptEventArg = acceptEventArg;
                acceptEventArg.Completed += acceptEventArg_Completed;

                if (!_listener.AcceptAsync(acceptEventArg))
                    ProcessAccept(acceptEventArg);

                _logger.LogInformation($"Game Server [{Id}] Started");

            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                try
                {
                    _logger.LogInformation($"Game Server [{Id}] Closing...");
                    //_listenerTokenSource.Cancel();
                    //_sendingTaskTokenSource.Cancel();

                    _acceptEventArg.Completed -= acceptEventArg_Completed;
                    _acceptEventArg.Dispose();
                    _acceptEventArg = null;

                    try
                    {
                        _listener.Close();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    int i = 1;
                    foreach (var session in _sessions.Values)
                    {
                        _logger.LogDebug("关闭第[{0}]个连接", i++);
                        try
                        {
                            CloseClientSocket(session.SocketAsyncEventArgs, ClientCloseReason.ServerClose);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, ex.Message);
                        }
                    }

                    _workingTaskTokenSource.Cancel();
                    _sendingTask.Join(10000);
                    _workingTask.Join(10000);

                    _users.Clear();

                    IsRunning = false;
                    _logger.LogInformation($"Game Server [{Id}] Closed");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                finally
                {
                    GC.Collect();
                }
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
            _logger.LogDebug($"当前连接数: {ClientCount}");
        }
        /// <summary>
        /// 连接断开
        /// </summary>
        protected virtual void OnSessionClosed(GameSession session)
        {
            _logger.LogDebug($"当前连接数: {ClientCount}");
        }

        /// <summary>
        /// 接收消息前，可用于重写Filter
        /// </summary>
        /// <returns>是否过滤掉</returns>
        protected virtual bool Filter(GameSession session, GameProtoHandlerInfo handler)
        {
            if (!handler.AllowAnonymous && !session.IsAuthorized)
            {
                return true;
            }
            return false;
        }

        #region 网络部分
        void acceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }

        void ProcessAccept(SocketAsyncEventArgs e)
        {
            Socket socket = null;

            if (e.SocketError != SocketError.Success)
            {
                var errorCode = (int)e.SocketError;

                //The listen socket was closed
                if (errorCode == 995 || errorCode == 10004 || errorCode == 10038)
                    return;

                _logger.LogError(new SocketException(errorCode), e.SocketError.ToString());
            }
            else
            {
                socket = e.AcceptSocket;
            }

            e.AcceptSocket = null;

            bool willRaiseEvent = false;

            try
            {
                willRaiseEvent = _listener.AcceptAsync(e);
            }
            catch (ObjectDisposedException)
            {
                //The listener was stopped
                //Do nothing
                //make sure ProcessAccept won't be executed in this thread
                willRaiseEvent = true;
            }
            catch (NullReferenceException)
            {
                //The listener was stopped
                //Do nothing
                //make sure ProcessAccept won't be executed in this thread
                willRaiseEvent = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                //make sure ProcessAccept won't be executed in this thread
                willRaiseEvent = true;
            }

            if (socket != null)
            {
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
                bool willRaiseEventRecv = socket.ReceiveAsync(args);
                if (!willRaiseEventRecv)
                {
                    ProcessReceive(args);
                }
            }

            if (!willRaiseEvent)
                ProcessAccept(e);
        }

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
            if (token == null)
                return;

            try
            {
                this.OnSessionClosed(token);
                if (token.Socket.Connected)
                    token.Socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                token.Socket.Close();
            }
            catch (Exception)
            {
                // ignored
            }

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
            while (!_workingTaskTokenSource.IsCancellationRequested)
            {
                try
                {
                    if (!_sendingQueue.IsEmpty)
                    {
                        while (_sendingQueue.TryDequeue(out var message))
                        {
                            var args = _socketSendArgsPool.Pop();
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

        internal GameSession CurrentWorkingSession;
        private void LoopWorking()
        {
            while (!_workingTaskTokenSource.IsCancellationRequested)
            {
                try
                {
                    if (!_workingQueue.IsEmpty)
                    {
                        while (_workingQueue.TryDequeue(out var task))
                        {
                            CurrentWorkingSession = task.Session;
                            int result = task.DoAction();

                            this.OnGameTaskDone(new GameTaskDoneEventArgs()
                            {
                                GameSession = task.Session,
                                ResultCode = result,
                            });
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
            if (cmd == null || !this._handlers.ContainsKey(cmd))
            {
                //如果没有处理器，先刷掉一批
                return false;
            }

            var handler = this._handlers[cmd];
            var type = handler.RequestType;
            if (Filter(session, handler))
            {
                return false;
            }

            var request = _serializer.Deserialize(type, data.Array, data.Offset, data.Count);
            var task = new GameRequestTask(handler, session, request);
            if (handler.AllowAnonymous)
            {
                //当遇到allowanonymous的任务时，即表示此任务不需要其他游戏逻辑线程同步，只要session同步即可，那么可以不放入逻辑线程而直接执行
                task.DoAction();
            }
            else
            {
                this._workingQueue.Enqueue(task);
            }
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
                    if(methodInfo.ReturnType != typeof(int))
                    {
                        _logger.LogWarning($"Method handler [{controller.GetType().Name}.{methodInfo.Name}] has wrong return type!");
                        continue;
                    }
                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    bool allowanonymous = methodInfo.GetCustomAttribute<AllowAnonymousAttribute>() != null;                    
                    if(parameterInfos.Length > 2 || parameterInfos.Length < 1)
                    {
                        _logger.LogWarning($"Protocol Handler {controller.GetType().Name }.{methodInfo.Name} parameters count wrong!");
                    }
                    else
                    {
                        List<Type> parameterTypes = new List<Type>();
                        foreach (var p in parameterInfos)
                        {
                            parameterTypes.Add(p.ParameterType);
                        }
                        var requestType = parameterTypes.FirstOrDefault(x=>x != typeof(GameSession));
                        if (requestType == null)
                        {
                            _logger.LogWarning($"Protocol Handler {controller.GetType().Name }.{methodInfo.Name} parameters not contains request entity!");
                            continue;
                        }
                        String cmd = requestType.Name;
                        Type methodGenericType;
                        GameProtoHandlerParameters paramSeq;
                        if (parameterTypes.Count == 1)
                        {
                            methodGenericType = typeof(Func<,>);
                            paramSeq = GameProtoHandlerParameters.Request;
                        }
                        else
                        {
                            methodGenericType = typeof(Func<,,>);
                            if (parameterTypes[0] == typeof(GameSession))
                            {
                                paramSeq = GameProtoHandlerParameters.GameSessionAndRequest;
                            }
                            else
                            {
                                paramSeq = GameProtoHandlerParameters.RequestAndGameSession;
                            }
                        }
                        parameterTypes.Add(typeof(int));
                        Type methodType = methodGenericType.MakeGenericType(parameterTypes.ToArray());
                        Delegate actionMethod = Delegate.CreateDelegate(methodType, controller, methodInfo);
                        var handler = new GameProtoHandlerInfo()
                        {
                            CMD = cmd,
                            MethodInfo = methodInfo,
                            ProcessAction = actionMethod,
                            RequestType = requestType,
                            Controller = controller,
                            AllowAnonymous = allowanonymous,
                            ParameterTypes = paramSeq
                        };
                        GameProtoHandlerInfo oldhandler = null;
                        if (!_handlers.TryGetValue(handler.CMD, out oldhandler))
                        {
                            _handlers.Add(handler.CMD, handler);
                            _serializer.Register(requestType);
                        }
                        else
                        {
                            _logger.LogWarning($"Request CMD [{handler.CMD}] in [{handler.Controller.GetType().Name }.{handler.MethodInfo.Name}] already declared in method: [{oldhandler.Controller.GetType().Name }.{oldhandler.MethodInfo.Name}]");
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
