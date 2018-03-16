using System;
using System.Collections.Generic;
using System.Text;

namespace protocol
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProtoAttribute : Attribute
    {
        public int value { get; set; }
        public string description { get; set; }
    }
}
