using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SKit
{
    public class GameSession
    {
        public string Id { get;  }
        public Socket Socket { get; internal set; }
        public DateTime CreateTime { get; internal set; }
        public GameServer Server { get; internal set; }

        /// <summary>
        /// 登录用户，请通过Login()函数设置
        /// </summary>
        public string UserName { get; private set; }
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

        public void Login(string username)
        {
            if (IsAuthorized)
            {
                return;
            }
            this.UserName = username;
            IsAuthorized = true;
            LoginTime = DateTime.Now;
        }

        public void Logout()
        {
            if (IsAuthorized)
            {
                this.UserName = null;
                this.IsAuthorized = false;
            }
        }
        
        /// <summary>
        /// 可读取的Buffer长度
        /// </summary>
        internal int BufferReaderCursor { get; set; }    
        internal SocketAsyncEventArgs SocketAsyncEventArgs { get; set; }
    }
}
