using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取任务活跃点奖励 协议:115
    /// </summary>
	[Proto(value=115,description="领取任务活跃点奖励")]
	[ProtoContract]
	public class QuestPointRewardRequest
	{
        /// <summary>
        ///  活跃点奖励id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int rewardid;

	}
}