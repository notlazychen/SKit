using System;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    class GameMessage
    {
        public Object Msg { get; set; }
        public MessageType MessageType { get; set; }
        public string DestId { get; set; }
    }

    enum MessageType
    {
        ToUser,
        AllUser,
        ToSession,
        AllSession
    }
}
