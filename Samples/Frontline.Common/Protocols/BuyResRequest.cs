using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买资源 协议:22
    /// </summary>
	[Proto(value=22,description="购买资源")]
	[ProtoContract]
	public class BuyResRequest
	{
        /// <summary>
        ///  资源类型（1军需2钢铁4黄金5原油
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;

	}
}