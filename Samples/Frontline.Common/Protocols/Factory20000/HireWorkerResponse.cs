using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 雇佣工人返回
    /// </summary>
	[Proto(value=-20002, description="雇佣工人返回")]
	[ProtoContract]
	public class HireWorkerResponse
    {
        [ProtoMember(1, IsRequired = false)]
        public bool success;
        [ProtoMember(2, IsRequired = false)]
        public string info;
        /// <summary>
        ///  雇到的工人
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public WorkerInfo worker;
	}
}