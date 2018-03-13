using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买限时活动礼包 协议:706
    /// </summary>
	[Proto(value=706,description="购买限时活动礼包")]
	[ProtoContract]
	public class BuyGiftRequest
	{
        /// <summary>
        ///  礼包id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string product_id;

	}
}