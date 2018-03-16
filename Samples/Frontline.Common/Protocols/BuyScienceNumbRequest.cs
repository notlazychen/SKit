using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买科研序列 协议:624
    /// </summary>
	[Proto(value=624,description="购买科研序列")]
	[ProtoContract]
	public class BuyScienceNumbRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}