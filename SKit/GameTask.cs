using System;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    /// <summary>
    /// 每收到一个消息包，创建一个任务
    /// </summary>
    public class GameTask
    {
        public GameTask(Delegate handler, GameSession session, Object entity, GameController controller)
        {
            ProcessAction = handler;
            Controller = controller;
            Entity = entity;
            Session = session;
        }
        public Delegate ProcessAction { get; private set; }

        public Object Entity { get; private set; }
        public GameSession Session { get; private set; }
        public GameController Controller { get; private set; }

        public virtual void DoAction()
        {
            this.ProcessAction.DynamicInvoke(Session, Entity);
        }
    }

    public class GamePlayerLeaveTask : GameTask
    {
        public ClientCloseReason Reason { get; private set; }
        public GamePlayerLeaveTask(GameSession session, GameController controller, ClientCloseReason reason) : base(null, session, null, controller)
        {
            Reason = reason;
        }

        public override void DoAction()
        {
            this.Controller.OnLeave(Session, Reason);
        }
    }
}
