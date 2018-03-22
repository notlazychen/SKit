using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 夺旗奖励领取结果 协议:-148
    /// </summary>
	[Proto(value=-148,description="夺旗奖励领取结果")]
	[ProtoContract]
	public class ReceiveGrabFlagScoreRewardResponse
	{
        /// <summary>
        ///  领取的奖励Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int rewardId;
        /// <summary>
        ///  奖励信息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo rewardInfo;
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