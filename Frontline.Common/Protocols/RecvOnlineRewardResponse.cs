using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取在线奖励 协议:-712
    /// </summary>
	[Proto(value=-712,description="领取在线奖励")]
	[ProtoContract]
	public class RecvOnlineRewardResponse
	{
        /// <summary>
        ///  下次可领取的时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long nextRecvTime;
        /// <summary>
        ///  本次得到的奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  下次可领的reward
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo nextReward;
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