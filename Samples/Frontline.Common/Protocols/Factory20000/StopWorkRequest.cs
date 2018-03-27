using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 撤回派遣
    /// </summary>
	[Proto(value=20006,description= "撤回派遣")]
	[ProtoContract]
	public class StopWorkRequest
    {
        [ProtoMember(1, IsRequired = false)]
        public String taskid;
	}
}