using System;

namespace Frontline.MQ
{
    public class ServerMessageInfo 
    {
        public string Address { get; set; }
        public short Cmd { get; set; }
        public object Entity { get; set; }

        public Type Type { get; set; }
    }
}
