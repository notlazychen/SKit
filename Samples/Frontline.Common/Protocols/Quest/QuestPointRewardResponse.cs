using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取任务活跃点奖励 协议:-115
    /// </summary>
	[Proto(value=-115,description="领取任务活跃点奖励")]
	[ProtoContract]
	public class QuestPointRewardResponse
	{
        /// <summary>
        ///  奖励id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int rewardid;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
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