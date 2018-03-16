using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买雪地营救次数 协议:224
    /// </summary>
	[Proto(value=224,description="购买雪地营救次数")]
	[ProtoContract]
	public class BuyRescueRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}