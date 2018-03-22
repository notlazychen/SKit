using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SKit
{
    public class GameSession : IDisposable
    {
        public string Id { get;  }
        public Socket Socket { get; internal set; }
        public DateTime CreateTime { get; internal set; }
        public GameServer Server { get; internal set; }

        private Dictionary<Type, Object> _cacheStore = new Dictionary<Type, object>();

        /// <summary>
        /// 登录用户，请通过Login()函数设置
        /// </summary>
        public string UserId { get; private set; }
        /// <summary>
        /// 是否登录，请通过Login()函数设置
        /// </summary>
        public bool IsAuthorized { get; private set; }
        /// <summary>
        /// 登录时间，请通过Login()函数设置
        /// </summary>
        public DateTime LoginTime { get; private set; }

        internal GameSession()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public void Login(string userid)
        {
            if (IsAuthorized)
            {
                return;
            }
            this.UserId = userid;
            this.Server.SetLogin(this);
            IsAuthorized = true;
            LoginTime = DateTime.Now;
        }

        public void Logout()
        {
            if (IsAuthorized)
            {
                this.UserId = null;
                this.IsAuthorized = false;
            }
        }
        
        /// <summary>
        /// 可读取的Buffer长度
        /// </summary>
        internal int BufferReaderCursor { get; set; }    
        internal SocketAsyncEventArgs SocketAsyncEventArgs { get; set; }

        public void SendAsync(Object msg)
        {
            if (IsAuthorized)
            {
                this.Server.SendByUserNameAsync(UserId, msg);
            }
            else
            {
                this.Server.SendBySessionIdAsync(this.Id, msg);
            }
        }

        public bool TryGetBind<T>(out T data) where T : class
        {
            Object o;
            bool result = _cacheStore.TryGetValue(typeof(T), out o);
            data = o as T;
            return data != null;
        }

        public T GetBind<T>() where T : class
        {
            Object o;
            if(_cacheStore.TryGetValue(typeof(T), out o))
            {
                return o as T;
            }
            return null;
        }

        public void SetBind<T>(T data)
        {
            _cacheStore[typeof(T)] = data;
        }

        public void Dispose()
        {
            _cacheStore.Clear();
        }
    }
}
