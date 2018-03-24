using System;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    public abstract class GameTask
    {
        public GameSession Session { get; private set; }

        public GameTask(GameSession session)
        {
            Session = session;
        }

        public void DoAction()
        {
            OnDoAction();
        }

        protected abstract void OnDoAction();
    }

    /// <summary>
    /// 每收到一个消息包，创建一个任务
    /// </summary>
    public class GameRequestTask : GameTask
    {
        public GameRequestTask(Delegate handler, GameSession session, Object entity) 
            : base(session)
        {
            ProcessAction = handler;
            Entity = entity;
        }

        public Delegate ProcessAction { get; private set; }

        public Object Entity { get; private set; }

        protected override void OnDoAction()
        {
            this.ProcessAction.DynamicInvoke(Entity);
        }
    }

    public class GamePlayerLeaveTask : GameTask
    {
        private readonly IEnumerable<GameController> _controllers;
        public ClientCloseReason Reason { get; private set; }
        public GamePlayerLeaveTask(GameSession session, ClientCloseReason reason, IEnumerable<GameController> controllers) 
            : base(session)
        {
            Reason = reason;
            _controllers = controllers;
        }

        protected override void OnDoAction()
        {
            foreach(var c in this._controllers)
            {
                c.OnLeave(Reason);
            }
        }
    }
}
