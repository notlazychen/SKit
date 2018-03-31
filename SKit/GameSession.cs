using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SKit
{
    public class GameSession : IDisposable
    {
        internal string Id { get;  }
        public Socket Socket { get; internal set; }
        public DateTime CreateTime { get; internal set; }
        public GameServer Server { get; internal set; }
        
        /// <summary>
        /// 登录用户，请通过Login()函数设置
        /// </summary>
        public string PlayerId { get; private set; }
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
            Id = Guid.NewGuid().ToString("D");
        }

        public void Login(string userid)
        {
            if (IsAuthorized)
            {
                return;
            }
            this.PlayerId = userid;
            this.Server.SetLogin(this);
            IsAuthorized = true;
            LoginTime = DateTime.Now;
        }

        public void Logout()
        {
            if (IsAuthorized)
            {
                this.PlayerId = null;
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
                this.Server.SendByUserNameAsync(PlayerId, msg);
            }
            else
            {
                this.Server.SendBySessionIdAsync(this.Id, msg);
            }
        }


        public event EventHandler<ClientCloseReason> PlayerLeave;

        internal void OnPlayerLeave(ClientCloseReason reason)
        {
            if (IsAuthorized)
            {
                PlayerLeave?.Invoke(this, reason);
            }
        }

        public void Dispose()
        {
            //_cacheStore.Clear();
        }
    }
}
