using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 解雇工人
    /// </summary>
	[Proto(value=20003,description="解雇工人")]
	[ProtoContract]
	public class FireWorkerRequest
	{
        /// <summary>
        /// 想解雇的工人Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public String workerId;

	}
}