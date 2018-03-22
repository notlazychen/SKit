using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取vip礼包返回 协议:-401
    /// </summary>
	[Proto(value=-401,description="领取vip礼包返回")]
	[ProtoContract]
	public class GetVIPGiftResponse
	{
        /// <summary>
        ///  想要领取的VIP礼包
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  领取得到的奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo rewardInfo;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diamond;
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