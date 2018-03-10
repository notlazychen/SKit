using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;

namespace SKit
{
    public abstract class GameController
    {
        //public GameSession CurrentSession { get; internal set; }

        //public virtual void OnConnected()
        //{
        //}

        /// <summary>
        /// 离开游戏的时候
        /// </summary>
        public virtual void OnLeave(GameSession session, ClientCloseReason reason)
        {
        }
    }
}