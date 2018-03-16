using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 重置工人 协议:117
    /// </summary>
	[Proto(value=117,description="重置工人")]
	[ProtoContract]
	public class ResetWorkerRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}