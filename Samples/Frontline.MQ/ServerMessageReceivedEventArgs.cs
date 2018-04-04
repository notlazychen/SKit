using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.MQ
{
    public class ServerMessageReceivedEventArgs : EventArgs
    {
        public ServerSession ServerSession { get; set; }
        public Object Entity { get; set; }
    }

    public class RelayMessageReceivedEventArgs : EventArgs
    {
        public string[] Receivers { get; set; }
        public byte[] Data { get; set; }
    }
}
