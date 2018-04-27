using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取vip礼包返回 协议:-401
    /// </summary>
	[Proto(value = -401, description = "领取vip礼包返回")]
    [ProtoContract]
    public class GetVIPGiftResponse
    {
        /// <summary>
        ///  领取得到的奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
        public RewardInfo rewardInfo;
    }
}