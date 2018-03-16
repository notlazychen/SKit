using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买限时礼包返回 协议:-706
    /// </summary>
	[Proto(value=-706,description="购买限时礼包返回")]
	[ProtoContract]
	public class BuyGiftResponse
	{
        /// <summary>
        ///  礼包id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string product_id;
        /// <summary>
        ///  更新的礼包
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public LimitGiftInfo gift;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}