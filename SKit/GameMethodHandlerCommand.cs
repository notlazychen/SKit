using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SKit
{
    public enum GameProtoHandlerParameters
    {
        Request,
        GameSessionAndRequest,
        RequestAndGameSession,
    }

    public class GameMethodHandlerCommand : GameCommandBase
    {
        public Delegate ProcessAction { get; internal set; }
        public MethodInfo MethodInfo { get; internal set; }
        public GameModule Module { get; internal set; }
        public GameProtoHandlerParameters ParameterTypes { get; internal set; }

        public override int ExecuteCommand()
        {
            switch (ParameterTypes)
            {
                case GameProtoHandlerParameters.Request:
                    return (int)this.ProcessAction.DynamicInvoke(RequestEntity);
                case GameProtoHandlerParameters.RequestAndGameSession:
                    return (int)this.ProcessAction.DynamicInvoke(RequestEntity, Session);
                case GameProtoHandlerParameters.GameSessionAndRequest:
                    return (int)this.ProcessAction.DynamicInvoke(Session, RequestEntity);
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{Module.GetType().FullName}.{MethodInfo.Name}";
        }

        protected override void OnInit()
        {
        }
    }
}
