using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买工人 协议:107
    /// </summary>
	[Proto(value=107,description="购买工人")]
	[ProtoContract]
	public class BuyWorkerRequest
	{
        /// <summary>
        ///  没用
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}