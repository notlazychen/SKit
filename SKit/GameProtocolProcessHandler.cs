using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SKit
{
    public class GameProtocolProcessHandler
    {
        public String CMD { get; set; }
        public Delegate ProcessAction { get; set; }
        public Type RequestType { get; set; }
        public MethodInfo MethodInfo { get; set; }

        public GameController Controller { get; set; }
        public bool AllowAnonymous { get; set;}
    }
}
