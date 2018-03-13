using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 挑战结束结果返回 协议:-143
    /// </summary>
	[Proto(value=-143,description="挑战结束结果返回")]
	[ProtoContract]
	public class GrabFlagBattleChallengeOverResponse
	{
        /// <summary>
        ///  对手pid
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string adversaryPid;
        /// <summary>
        ///  获得的排名突破奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<FlagBreakRankReward> rewards;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  剩余挑战次数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int remainChallengeTimes;
        /// <summary>
        ///  原来排名
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int orginalRank;
        /// <summary>
        ///  当前排名（也就是敌方原来的排名）
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int currentRank;
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int score;
        /// <summary>
        ///  冷却截止时间
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public long nextTime;
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