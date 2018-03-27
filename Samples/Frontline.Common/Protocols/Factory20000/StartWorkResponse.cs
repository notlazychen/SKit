using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 派遣
    /// </summary>
	[Proto(value=-20005,description= "派遣")]
	[ProtoContract]
	public class StartWorkResponse
    {
        [ProtoMember(1, IsRequired = false)]
        public bool success;
        [ProtoMember(2, IsRequired = false)]
        public string info;
        
        [ProtoMember(3, IsRequired = false)]
		public WorkTaskInfo taskInfo;
	}
}