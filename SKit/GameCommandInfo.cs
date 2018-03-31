using System;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    public class GameCommandInfo
    {
        public GameCommandBase Command { get;internal set; }
        public Type RequestType { get; internal set; }
        public String CMD { get; internal set; }

        public bool AllowAnonymous { get; internal set; }
        public bool Asynchronous { get; internal set; }
    }
}
