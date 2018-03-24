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

        public int DoAction()
        {
            return OnDoAction();
        }

        protected abstract int OnDoAction();
    }

    /// <summary>
    /// 每收到一个消息包，创建一个任务
    /// </summary>
    public class GameRequestTask : GameTask
    {
        public GameRequestTask(GameProtoHandlerInfo handler, GameSession session, Object entity) 
            : base(session)
        {
            Handler = handler;
            Entity = entity;
        }

        public GameProtoHandlerInfo Handler { get; private set; }

        public Object Entity { get; private set; }

        protected override int OnDoAction()
        {
            var parameters = new List<Object>();
            switch (Handler.ParameterTypes)
            {
                case GameProtoHandlerParameters.Request:
                    return (int)this.Handler.ProcessAction.DynamicInvoke(Entity);
                case GameProtoHandlerParameters.RequestAndGameSession:
                    return (int)this.Handler.ProcessAction.DynamicInvoke(Entity, Session);
                case GameProtoHandlerParameters.GameSessionAndRequest:
                    return (int)this.Handler.ProcessAction.DynamicInvoke(Session, Entity);
            }
            return 0;
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

        protected override int OnDoAction()
        {
            foreach(var c in this._controllers)
            {
                c.OnLeave(Reason);
            }
            return 0;
        }
    }
}
