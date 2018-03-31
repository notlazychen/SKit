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
    public interface IGameCommand
    {
        int ExecuteCommand();
    }

    public abstract class GameCommandBase : IGameCommand
    {
        public GameServer Server { get; internal set; }
        public GameSession Session { get; internal set; }
        internal Object RequestEntity { get; set; }

        internal void Init()
        {
            OnInit();
        }
        protected abstract void OnInit();

        public abstract int ExecuteCommand();
    }

    public abstract class GameCommand<T> : GameCommandBase
        where T : class
    {
        public T Request { get { return RequestEntity as T; } }

        public override string ToString()
        {
            return $"{this.GetType().FullName}";
        }
    }
}