using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 天梯战斗结束（推送） 协议:-601
    /// </summary>
	[Proto(value=-601,description="天梯战斗结束（推送）")]
	[ProtoContract]
	public class LadderBattleOverNotify
	{
        /// <summary>
        ///  参加者
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<LadderPlayerBattleInfo> players;
        /// <summary>
        ///  奖励
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