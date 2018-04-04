using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SKit
{
    public abstract class GameTask
    {
        public int DoAction()
        {
            return OnDoAction();
        }

        protected abstract int OnDoAction();
    }

    public abstract class GamePlayerTask : GameTask
    {
        public GameSession Session { get; private set; }

        public GamePlayerTask(GameSession session)
        {
            Session = session;
        }        
    }

    /// <summary>
    /// 每收到一个消息包，创建一个任务
    /// </summary>
    public class GameRequestTask : GamePlayerTask
    {
        private Object Entity;
        public GameRequestTask(GameCommandBase command, GameSession session, Object entity) 
            : base(session)
        {
            Command = command;
            Entity = entity;
        }

        public GameCommandBase Command { get; private set; }

        protected override int OnDoAction()
        {
            Command.RequestEntity = this.Entity;
            Command.Session = this.Session;
            return Command.ExecuteCommand();
        }
    }

    public class GamePlayerLeaveTask : GamePlayerTask
    {
        private readonly IEnumerable<GameModule> _controllers;
        public ClientCloseReason Reason { get; private set; }
        public GamePlayerLeaveTask(GameSession session, ClientCloseReason reason, IEnumerable<GameModule> controllers)
            : base(session)
        {
            Reason = reason;
            _controllers = controllers;
        }

        protected override int OnDoAction()
        {
            Session.OnPlayerLeave(Reason);
            return 0;
        }
    }


    public class GameInvokeTask : GameTask
    {
        private Action _action;
        private bool _wait;
        public GameInvokeTask(Action action, bool wait)
        {
            _wait = wait;
            _action = action;
        }

        protected override int OnDoAction()
        {
            try
            {
                if (_wait)
                {
                    Monitor.Enter(this);
                }
                _action();
            }
            finally
            {
                if (_wait)
                {
                    Monitor.Pulse(this);
                    Monitor.Exit(this);
                    _wait = false;
                }
            }
            return 0;
        }
    }
}
