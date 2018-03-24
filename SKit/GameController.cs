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
        /// <summary>
        /// 获取当前执行线程中的GameSession
        /// </summary>
        /// <remarks>注意不要在匿名允许的处理函数中使用, 匿名session处理函数为异步调用, 并不存在CurrenSession</remarks>
        public GameSession CurrentSession => this.Server.CurrentWorkingSession;


        internal void RegisterEvents()
        {
            OnReadGameDesignTables();
            OnRegisterEvents();
        }

        public void ReadGameDesigns()
        {
            OnReadGameDesignTables();
        }

        /// <summary>
        /// 建议在此处通过DI获得其他Controller并注册事件
        /// </summary>
        protected virtual void OnRegisterEvents()
        {

        }

        protected virtual void OnReadGameDesignTables()
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