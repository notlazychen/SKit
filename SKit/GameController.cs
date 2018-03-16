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
        public GameServer Server { get; internal set; }
        public GameSession CurrentSession { get { return this.Server._currentWorkingSession;  } }


        internal void RegisterEvents()
        {
            OnRegisterEvents();
        }

        /// <summary>
        /// 建议在此处通过DI获得其他Controller并注册事件
        /// </summary>
        protected virtual void OnRegisterEvents()
        {

        }
        //public virtual void OnConnected()
        //{
        //}

        /// <summary>
        /// 离开游戏的时候
        /// </summary>
        public virtual void OnLeave(ClientCloseReason reason)
        {
        }
    }
}