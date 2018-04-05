using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace SKit
{
    public abstract class GameModule
    {
        public GameServer Server { get; internal set; }

        /// <summary>
        /// 获取当前执行线程中的GameSession
        /// </summary>
        /// <remarks>注意不要在匿名允许的处理函数中使用, 匿名session处理函数为异步调用, 并不存在CurrenSession</remarks>
        public GameSession Session
        {
            get
            {
                if (Thread.CurrentThread.Name != GameServer.MainWorldThreadName)
                {
                    throw new Exception("错误的使用方式, 在异步调用中无法使用本属性");
                }
                return this.Server.CurrentWorkingSession;
            }
        }

        private ILogger _logger;

        internal void ConfigureServices()
        {
            OnConfiguringModules();
        }

        internal void Configure()
        {
            OnConfigured();
        }

        /// <summary>
        /// 建议在此处获得其他Module并注册事件
        /// </summary>
        protected virtual void OnConfiguringModules() { }

        /// <summary>
        /// 建议在此处执行
        /// </summary>
        /// <remarks>此方法执行在ConfigureModules之后</remarks>
        protected virtual void OnConfigured() { }
        /// <summary>
        /// 当服务器停止时
        /// </summary>
        public virtual void OnServerClosing()
        {

        }
    }
}