using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求领取vip礼包 协议:401
    /// </summary>
	[Proto(value=401,description="请求领取vip礼包")]
	[ProtoContract]
	public class GetVIPGiftRequest
	{
        /// <summary>
        ///  想要领取的VIP礼包等级，一键领取为-1
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int vip;

	}
}