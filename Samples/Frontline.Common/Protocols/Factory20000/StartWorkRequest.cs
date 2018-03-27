using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 派遣
    /// </summary>
	[Proto(value=20005,description= "派遣")]
	[ProtoContract]
	public class StartWorkRequest
    {
        [ProtoMember(1, IsRequired = false)]
        public String taskid;
        [ProtoMember(2, IsRequired = false)]
		public List<String> workers;
	}
}