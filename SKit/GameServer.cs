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
using System.Runtime.InteropServices;
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
        public string Name { get; }
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


        //private readonly ElasticPool<SocketAsyncEventArgs> _socketRecvArgsPool;//输入缓冲池
        //private readonly ElasticPool<SocketAsyncEventArgs> _socketSendArgsPool;//输出缓冲池

        private readonly ElasticPool<byte[]> _socketRecvBufferPool;//输入缓冲池
        private readonly ElasticPool<byte[]> _socketSendBufferPool;//输出缓冲池

        private readonly Serializer _serializer;//正反序列化(包括拆包打包)工具
        private SKitConfig Config { get; }//配置
        private readonly IServiceCollection _services;//DI容器

        #region 计划任务
        private class Schedule
        {
            public DateTime Time { get; set; }
            public Action<DateTime> Action { get; set; }
        }
        private List<Schedule> _schedule = new List<Schedule>();
        public void AddSchedule(DateTime time, Action<DateTime> action)
        {
            var schedule = new Schedule { Time = time, Action = action };
            if (_schedule.Any())
            {
                int i = 0;
                while (true)
                {
                    var cur = _schedule[i];
                    if (schedule.Time < cur.Time)
                    {
                        _schedule.Insert(i, schedule);
                        break;
                    }
                    else
                    {
                        i++;
                        if(_schedule.Count == i)
                        {
                            _schedule.Add(schedule);
                            break;
                        }
                    }
                }
            }
            else
            {
                _schedule.Add(schedule);
            }
        }

        public bool TryDoSchedule()
        {
            bool isdone = false;

            var now = DateTime.Now;
            var act = _schedule.FirstOrDefault();
            while (act != null)
            {
                if(act.Time < now)
                {
                    try
                    {
                        act.Action(act.Time);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                        this.UnhandledExceptionCatched?.Invoke(this, ex);
                    }
                    isdone = true;
                    _schedule.Remove(act);
                    act = _schedule.FirstOrDefault();
                }
                else
                {
                    break;
                }
            }

            return isdone;
        }
        #endregion

        #region 连接管理
        private readonly ConcurrentDictionary<string, GameSession> _sessions = new ConcurrentDictionary<string, GameSession>();//所有连接 Key:SessionId
        private readonly ConcurrentDictionary<string, GameSession> _users = new ConcurrentDictionary<string, GameSession>();//登录的连接 Key:UserName
        #endregion

        //private readonly Dictionary<string, GameProtoHandlerInfo> _handlers = new Dictionary<string, GameProtoHandlerInfo>();
        private readonly Dictionary<string, GameCommandInfo> _commands = new Dictionary<string, GameCommandInfo>();
        private readonly Dictionary<Type, GameModule> _modules = new Dictionary<Type, GameModule>();
        public IEnumerable<GameModule> Modules
        {
            get
            {
                return _modules.Values;
            }
        }
        public IEnumerable<GameCommandInfo> CommandInfos
        {
            get
            {
                return _commands.Values;
            }
        }
        /// <summary>
        /// 核心监听客户端TCP
        /// </summary>
        private Socket _listener;
        private readonly ILogger<GameServer> _logger;

        #region 事件
        public event GameServerEvent<GameServer, Exception> UnhandledExceptionCatched;

        public event GameServerEvent<GameSession, int> GameTaskDone;
        private void OnGamePlayerTaskDone(GameSession session, int result)
        {
            GameTaskDone?.Invoke(session, result);
        }
        public event GameServerEvent<GameServer, DateTime> GameScheduleDone;
        private void OnGameScheduleTaskDone()
        {
            GameScheduleDone?.Invoke(this, DateTime.Now);
        }

        public delegate void GameServerEvent<T1, T2>(T1 t, T2 e);

        /// <summary>
        /// 连接断开
        /// </summary>
        public event EventHandler<SessionCloseEventArgs> SessionClosed;
        private void OnSessionClosed(GameSession session, ClientCloseReason reason)
        {
            SessionClosed?.Invoke(this, new SessionCloseEventArgs() { GameSession = session, Reason = reason });
        }
        /// <summary>
        /// 有新的连接建立
        /// </summary>
        /// <param name="session"></param>
        /// <remarks>这里是网络通信部分，与游戏逻辑处理不是同一线程</remarks>
        public event EventHandler<SessionEnterEventArgs> NewSessionEnter;
        private void OnNewSessionConnected(GameSession session)
        {
            _logger.LogDebug($"当前连接数: {ClientCount}");
            NewSessionEnter?.Invoke(this, new SessionEnterEventArgs() { GameSession = session });
        }
        #endregion

        #region 开放方法
        public GameServer(IServiceCollection services)
        {
            _services = services;
            var provicer = _provider = services.BuildServiceProvider();
            _configuration = _provider.GetService<IConfiguration>();
            Config = provicer.GetService<IOptions<SKitConfig>>().Value;
            Debug.Assert(Config != null, "SKitConfig Can't be NULL!");
            _serializer = provicer.GetService<Serializer>();
            Debug.Assert(_serializer != null, "ISerializable Can't be NULL!");
            _logger = provicer.GetService<ILogger<GameServer>>();
            Debug.Assert(_logger != null, "ILogger Can't be NULL!");
            this.Id = Config.Id;
            this.Name = Config.Name;

            _socketRecvBufferPool = new ElasticPool<byte[]>(() =>
            {
                var buff = new byte[Config.RecvBufferSize];
                return buff;
            }, Config.PresetUserCount);
            _socketSendBufferPool = new ElasticPool<byte[]>(() =>
            {
                var buff = new byte[Config.SendBufferSize];
                return buff;
            }, Config.PresetUserCount);
            //_listener.AllowNatTraversal(true);
        }

        ServiceProvider _provider;
        IConfiguration _configuration;
        public string GetConfig(string key)
        {
            //var provider = _services.BuildServiceProvider();
            return _configuration[key];
        }

        private const int SOL_SOCKET_OSX = 0xffff;
        private const int SO_REUSEADDR_OSX = 0x0004;
        private const int SOL_SOCKET_LINUX = 0x0001;
        private const int SO_REUSEADDR_LINUX = 0x0002;
        [DllImport("libc", SetLastError = true)]
        private static extern int setsockopt(int socket, int level, int option_name, IntPtr option_value, uint option_len);
        // Without setting SO_REUSEADDR on macOS and Linux, binding to a recently used endpoint can fail.
        // https://github.com/dotnet/corefx/issues/24562
        private unsafe void EnableRebinding(Socket listenSocket)
        {
            var optionValue = 1;
            var setsockoptStatus = 0;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                setsockoptStatus = setsockopt(listenSocket.Handle.ToInt32(), SOL_SOCKET_LINUX, SO_REUSEADDR_LINUX,
                                              (IntPtr)(&optionValue), sizeof(int));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                setsockoptStatus = setsockopt(listenSocket.Handle.ToInt32(), SOL_SOCKET_OSX, SO_REUSEADDR_OSX,
                                              (IntPtr)(&optionValue), sizeof(int));
            }

            if (setsockoptStatus != 0)
            {
                _logger.LogError($"Setting SO_REUSEADDR failed with errno '{ Marshal.GetLastWin32Error()}'.");
            }
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        public void Start()
        {
            try
            {
                if (!IsRunning)
                {
                    //反射
                    this.ReflectProtocols();

                    _logger.LogInformation($"启动工作线程...");
                    IsRunning = true;

                    //启动任务工作线程
                    _workingTaskTokenSource = new CancellationTokenSource();
                    _workingTask = new Thread(LoopWorking);
                    _workingTask.Name = MainWorldThreadName;
                    _workingTask.Start();

                    _logger.LogInformation($"启动序列化线程...");
                    //启动发送线程
                    //_sendingTaskTokenSource = new CancellationTokenSource();
                    _sendingTask = new Thread(LoopSending);
                    _sendingTask.Start();

                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Config.Port);
                    _listener = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    EnableRebinding(_listener);
                    _listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                    //_listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                    _logger.LogInformation($"绑定端口{Config.Port}");
                    _listener.Bind(endPoint);
                    _listener.Listen(Config.Backlog);

                    SocketAsyncEventArgs acceptEventArg = new SocketAsyncEventArgs();
                    _acceptEventArg = acceptEventArg;
                    acceptEventArg.Completed += acceptEventArg_Completed;

                    _logger.LogInformation($"开启监听");
                    if (!_listener.AcceptAsync(acceptEventArg))
                        ProcessAccept(acceptEventArg);
                    _logger.LogInformation($"服务器[{Id}]已启动");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                try
                {
                    _logger.LogInformation($"Game Server [{Id}] Closing...");
                    //各模块自行qingli 
                    foreach (var module in _modules.Values)
                    {
                        _logger.LogInformation($"Module [{module.GetType().Name}] Close");
                    }
                    this.ServerClosing?.Invoke(this, DateTime.Now);

                    if (_acceptEventArg != null)
                    {
                        _acceptEventArg.Completed -= acceptEventArg_Completed;
                        _acceptEventArg.Dispose();
                        _acceptEventArg = null;
                    }

                    try
                    {
                        _listener.Dispose();
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
                    _sendingTask.Join();
                    _workingTask.Join();

                    _users.Clear();

                    IsRunning = false;
                    _logger.LogInformation($"Game Server [{Id}] Closed");
                    this.ServerClosing?.Invoke(this, DateTime.Now);
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

        public void InvokeGameTask(Action action, bool wait = false)
        {
            var task = new GameInvokeTask(action, wait);
            if (wait)
            {
                Monitor.Enter(task);
            }
            _workingQueue.Enqueue(task);
            if (wait)
            {
                Monitor.Wait(task);
                Monitor.Exit(task);
            }
        }

        internal void SetLogin(GameSession session)
        {
            _users.AddOrUpdate(session.PlayerId, session, (username, oldSession) =>
            {
                //把原来的玩家踢下线
                CloseClientSocket(oldSession.SocketAsyncEventArgs, ClientCloseReason.Displacement);
                oldSession.Logout();
                return session;
            });
        }

        public bool IsOnline(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;
            return _users.ContainsKey(username);
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

        public void MultiSendByUserNameAsync(IEnumerable<string> usernames, Object msg)
        {
            GameMessage gmsg = new GameMessage()
            {
                MessageType = MessageType.ToMultiUsers,
                Msg = msg,
                DestIds = usernames
            };
            _sendingQueue.Enqueue(gmsg);
        }

        public void SendToSession(GameSession session, Object msg)
        {
            var buff = _socketSendBufferPool.Pop();
            try
            {
                int size = _serializer.Serialize(msg, buff, buff.Length);
                //ArraySegment<byte> encodedMessage = _serializer.Serialize(data, buff, 0, buff.Length);
                session.Socket.Send(buff, 0, size, SocketFlags.None);
            }
            catch (Exception)
            {
                //
            }
            finally
            {
                _socketSendBufferPool.Push(buff);
            }
        }

        /// <summary>
        /// 发送给指定登录用户
        /// </summary>
        public void MultiSendByUserName(byte[] data, params string[] usersnames)
        {
            if (usersnames == null)
                return;
            foreach (var username in usersnames)
            {
                if (_users.TryGetValue(username, out var session))
                {
                    session.Socket.Send(data, 0, data.Length, SocketFlags.None);
                }
            }
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

        public GameSession FindSessionByPlayerId(string playerId)
        {
            _users.TryGetValue(playerId, out var session);
            return session;
        }
        #endregion

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
                //The listen socket was closed
                if (e.SocketError == SocketError.OperationAborted
                    || e.SocketError == SocketError.Interrupted
                    || e.SocketError == SocketError.InvalidArgument
                    || e.SocketError == SocketError.NotSocket)
                    return;

                _logger.LogError(new SocketException((int)e.SocketError), e.SocketError.ToString());
            }
            else
            {
                socket = e.AcceptSocket;
                socket.NoDelay = true;
                //socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
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

            try
            {
                if (socket != null)
                {
                    var args = new SocketAsyncEventArgs();
                    var buff = _socketRecvBufferPool.Pop();
                    args.SetBuffer(buff, 0, buff.Length);
                    args.Completed += IO_Completed;

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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
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
                var data = _serializer.UnPack(e.Buffer, from, session.BufferReaderCursor, ref readlength);
                if (readlength > 0)
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
                    foreach (var data in datas)
                    {
                        //消息处理: 反序列化和筛选
                        if (!ProcessRecevedData(session, data))
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
                if (_sessions.TryRemove(token.Id, out _))
                {
                    if (token.PlayerId != null && _users.TryRemove(token.PlayerId, out _))
                    {
                        var task = new GamePlayerLeaveTask(token, reason, _modules.Values);
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
                        }
                    }
                    _socketRecvBufferPool.Push(e.Buffer);
                    e.Completed -= IO_Completed;
                    e.Dispose();
                    token?.Dispose();
                    // Free the SocketAsyncEventArg so they can be reused by another client
                    _logger.LogDebug($"{token.Id}: LEAVE, reason: {reason}|当前连接数: {ClientCount}");
                }
                
                this.OnSessionClosed(token, reason);
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
        }

        private void AfterSendReleaseBuffer(SocketAsyncEventArgs e)
        {
            try
            {
                _socketSendBufferPool.Push(e.Buffer);
                e.Completed -= IO_Completed;
                e.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        private void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    AfterSendReleaseBuffer(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }
        }
        #endregion

        #region 任务执行派发部分
        private void BeginSendSocketMessage(Socket socket, SocketAsyncEventArgs args)
        {
            bool isevent = false;
            try
            {
                isevent = socket.SendAsync(args);
            }
            catch(Exception)
            {
                //ignore
            }
            finally
            {
                if (!isevent)
                {
                    AfterSendReleaseBuffer(args);
                }
            }
        }

        private void LoopSending()
        {
            while (!_workingTaskTokenSource.IsCancellationRequested)
            {
                try
                {
                    if (_sendingQueue.TryDequeue(out var message))
                    {
                        switch (message.MessageType)
                        {
                            case MessageType.AllSession:
                                {
                                    foreach (var session in _sessions.Values)
                                    {
                                        var args = new SocketAsyncEventArgs();
                                        args.Completed += IO_Completed;
                                        var buff = _socketSendBufferPool.Pop();
                                        int size = _serializer.Serialize(message.Msg, buff, buff.Length);
                                        args.SetBuffer(buff, 0, size);

                                        BeginSendSocketMessage(session.Socket, args);
                                    }
                                }
                                break;
                            case MessageType.AllUser:
                                {
                                    foreach (var session in _users.Values)
                                    {
                                        var args = new SocketAsyncEventArgs();
                                        args.Completed += IO_Completed;
                                        var buff = _socketSendBufferPool.Pop();
                                        int size = _serializer.Serialize(message.Msg, buff, buff.Length);
                                        args.SetBuffer(buff, 0, size);

                                        BeginSendSocketMessage(session.Socket, args);
                                    }
                                }
                                break;
                            case MessageType.ToSession:
                                {
                                    if (_sessions.TryGetValue(message.DestId, out var session))
                                    {
                                        var args = new SocketAsyncEventArgs();
                                        args.Completed += IO_Completed;
                                        var buff = _socketSendBufferPool.Pop();
                                        int size = _serializer.Serialize(message.Msg, buff, buff.Length);
                                        args.SetBuffer(buff, 0, size);

                                        BeginSendSocketMessage(session.Socket, args);
                                    }
                                }
                                break;
                            case MessageType.ToUser:
                                {
                                    if (_users.TryGetValue(message.DestId, out var session))
                                    {
                                        var args = new SocketAsyncEventArgs();
                                        args.Completed += IO_Completed;
                                        var buff = _socketSendBufferPool.Pop();
                                        int size = _serializer.Serialize(message.Msg, buff, buff.Length);
                                        args.SetBuffer(buff, 0, size);

                                        BeginSendSocketMessage(session.Socket, args);
                                    }
                                }
                                break;
                            case MessageType.ToMultiUsers:
                                {
                                    if (message.DestIds != null)
                                    {
                                        var args = new SocketAsyncEventArgs();
                                        args.Completed += IO_Completed;
                                        var buff = _socketSendBufferPool.Pop();
                                        int size = _serializer.Serialize(message.Msg, buff, buff.Length);
                                        args.SetBuffer(buff, 0, size);
                                        foreach (var username in message.DestIds)
                                        {
                                            if (_users.TryGetValue(username, out var session))
                                            {
                                                BeginSendSocketMessage(session.Socket, args);
                                            }
                                        }
                                    }
                                }
                                break;
                            case MessageType.ToMultiSessions:
                                {
                                    if (message.DestIds != null)
                                    {
                                        var args = new SocketAsyncEventArgs();
                                        args.Completed += IO_Completed;
                                        var buff = _socketSendBufferPool.Pop();
                                        int size = _serializer.Serialize(message.Msg, buff, buff.Length);
                                        args.SetBuffer(buff, 0, size);
                                        foreach (var id in message.DestIds)
                                        {
                                            if (_sessions.TryGetValue(id, out var session))
                                            {
                                                BeginSendSocketMessage(session.Socket, args);
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        Thread.Sleep(1);
                    }
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
                    if (_workingQueue.TryDequeue(out var task))
                    {
                        var t = task as GamePlayerTask;
                        if (t != null)
                        {
                            CurrentWorkingSession = t.Session;
                            int result = task.DoAction();
                            this.OnGamePlayerTaskDone(t.Session, result);
                        }
                        else
                        {
                            task.DoAction();
                        }
                    }
                    else
                    {
                        if (TryDoSchedule())
                        {
                            this.OnGameScheduleTaskDone();
                        }
                        else
                        {
                            Thread.Sleep(1);
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    this.UnhandledExceptionCatched?.Invoke(this, ex);
                }
            }
        }

        /// <summary>
        /// 处理消息包
        /// </summary>
        /// <returns>是否执行成功</returns>
        protected bool ProcessRecevedData(GameSession session, ArraySegment<byte> data)
        {
            string cmd = _serializer.DataToCmd(data.Array, data.Offset, data.Count);
            if (cmd == null || !this._commands.ContainsKey(cmd))
            {
                //如果没有处理器，先刷掉一批
                return false;
            }

            var cmdInfo = this._commands[cmd];
            var type = cmdInfo.RequestType;
            if (!cmdInfo.AllowAnonymous && !session.IsAuthorized)
            {
                return false;
            }

            var request = _serializer.Deserialize(type, data.Array, data.Offset, data.Count);
            var task = new GameRequestTask(cmdInfo.Command, session, request);
            if (cmdInfo.Asynchronous)
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
        public T GetModule<T>() where T : GameModule
        {
            Type t = typeof(T);
            return _modules[t] as T;
        }
        /// <summary>
        /// 消息驱动，通过消息实体名找处理函数
        /// </summary>
        private void ReflectProtocols()
        {
            _logger.LogInformation($"开始读取模块");
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(GameModule))
                {
                    _services.AddTransient(typeof(GameModule), type);
                }
            }

            var provider = _services.BuildServiceProvider();
            var modules = provider.GetServices<GameModule>();
            foreach (var module in modules)
            {
                Type type = module.GetType();
                module.Server = this;
                _modules.Add(type, module);

                //加载handler并转化为command
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                foreach (var methodInfo in methods)
                {
                    if (methodInfo.IsSpecialName || !methodInfo.Name.StartsWith("Call_"))
                    {
                        continue;
                    }
                    if (methodInfo.ReturnType != typeof(int))
                    {
                        _logger.LogWarning($"Method handler [{module.GetType().Name}.{methodInfo.Name}] has wrong return type!");
                        continue;
                    }
                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    if (parameterInfos.Length > 2 || parameterInfos.Length < 1)
                    {
                        _logger.LogWarning($"Protocol Handler {module.GetType().Name }.{methodInfo.Name} parameters count wrong!");
                    }
                    else
                    {
                        List<Type> parameterTypes = new List<Type>();
                        foreach (var p in parameterInfos)
                        {
                            parameterTypes.Add(p.ParameterType);
                        }
                        var requestType = parameterTypes.FirstOrDefault(x => x != typeof(GameSession));
                        if (requestType == null)
                        {
                            _logger.LogWarning($"Protocol Handler {module.GetType().Name }.{methodInfo.Name} parameters not contains request entity!");
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
                        Delegate actionMethod = Delegate.CreateDelegate(methodType, module, methodInfo);

                        var options = methodInfo.GetCustomAttribute<GameCommandOptionsAttribute>();
                        var commandInfo = new GameCommandInfo()
                        {
                            CMD = cmd,
                            RequestType = requestType,
                            Command = new GameMethodHandlerCommand()
                            {
                                MethodInfo = methodInfo,
                                Module = module,
                                ProcessAction = actionMethod,
                                ParameterTypes = paramSeq,
                                Server = this,
                            }
                        };
                        if (options != null)
                        {
                            commandInfo.AllowAnonymous = options.AllowAnonymous;
                            commandInfo.Asynchronous = options.Asynchronous;
                            commandInfo.CMD = options.CMD ?? requestType.Name;
                        }
                        if (!_commands.TryGetValue(commandInfo.CMD, out var old))
                        {
                            _commands.Add(commandInfo.CMD, commandInfo);
                            _serializer.Register(requestType);
                        }
                        else
                        {
                            _logger.LogWarning($"Request CMD [{commandInfo.CMD}] in [{commandInfo.Command.ToString()}] already declared in method: [{old.Command.ToString()}]");
                        }
                    }
                }
            }

            //加载command
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.BaseType != null && type.BaseType.IsGenericType)
                {
                    if (type.BaseType.BaseType == typeof(GameCommandBase))
                    {
                        var requestType = type.BaseType.GetGenericArguments()[0];
                        var options = type.GetCustomAttribute<GameCommandOptionsAttribute>();
                        var command = Activator.CreateInstance(type) as GameCommandBase;
                        command.Server = this;
                        var commandInfo = new GameCommandInfo()
                        {
                            Command = command,
                            RequestType = requestType,
                            CMD = requestType.Name
                        };
                        if (options != null)
                        {
                            commandInfo.AllowAnonymous = options.AllowAnonymous;
                            commandInfo.Asynchronous = options.Asynchronous;
                            commandInfo.CMD = options.CMD ?? requestType.Name;
                        }
                        if (!_commands.TryGetValue(commandInfo.CMD, out var old))
                        {
                            _commands.Add(commandInfo.CMD, commandInfo);
                            _serializer.Register(requestType);
                        }
                        else
                        {
                            _logger.LogWarning($"Request CMD [{commandInfo.CMD}] in [{commandInfo.Command.ToString()}] already declared in method: [{old.Command.ToString()}]");
                        }
                    }
                }
            }

            //模块初始化
            foreach (var module in modules)
            {
                //_logger.LogInformation($"加载模块:{module.GetType().Name}");
                module.ConfigureServices();
            }
            foreach (var module in modules)
            {
                _logger.LogInformation($"配置模块:{module.GetType().Name}");
                module.Configure();
            }

            //命令初始化
            foreach (var command in _commands.Values)
            {
                command.Command.Init();
            }

            this.ServerStarted?.Invoke(this, DateTime.Now);
        }

        #endregion

        public event GameServerEvent<GameServer, DateTime> ServerClosing;
        public event GameServerEvent<GameServer, DateTime> ServerClosed;
        public event GameServerEvent<GameServer, DateTime> ServerStarted;
    }
}
