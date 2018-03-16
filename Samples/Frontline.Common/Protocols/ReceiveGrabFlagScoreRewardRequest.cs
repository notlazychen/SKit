using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求领取夺旗积分奖励 协议:148
    /// </summary>
	[Proto(value=148,description="请求领取夺旗积分奖励")]
	[ProtoContract]
	public class ReceiveGrabFlagScoreRewardRequest
	{
        /// <summary>
        ///  欲领取的奖励所需的积分
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int rewardId;

	}
}