using System;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    public class GameTaskDoneEventArgs : EventArgs
    {
        public int ResultCode { get; set; }
        public GameSession GameSession { get; set; }
    }
}
