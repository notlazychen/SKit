using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 撤回派遣
    /// </summary>
	[Proto(value=-20006,description= "撤回派遣")]
	[ProtoContract]
	public class StopWorkResponse
    {
        [ProtoMember(1, IsRequired = false)]
        public bool success;
        [ProtoMember(2, IsRequired = false)]
        public string info;
        
        [ProtoMember(3, IsRequired = false)]
		public WorkTaskInfo taskInfo;
	}
}