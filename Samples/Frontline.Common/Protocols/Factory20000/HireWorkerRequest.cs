using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 雇佣工人
    /// </summary>
	[Proto(value=20002,description="雇佣工人")]
	[ProtoContract]
	public class HireWorkerRequest
	{
        /// <summary>
        /// 想雇佣的劳力id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public String id;

	}
}