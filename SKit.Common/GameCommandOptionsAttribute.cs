using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common
{
    public class GameCommandOptionsAttribute : Attribute
    {
        public bool AllowAnonymous { get; private set; } = false;
        public bool Asynchronous { get; private set; } = false;
        public string CMD { get; set; }

        public GameCommandOptionsAttribute(string cmd = null, bool allowAnonymous = false, bool asynchronous = false)
        {
            AllowAnonymous = allowAnonymous;
            Asynchronous = asynchronous;
            CMD = cmd;
        }
    }
}
