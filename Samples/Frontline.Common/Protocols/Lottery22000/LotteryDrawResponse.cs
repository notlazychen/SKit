using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 抽奖
    /// </summary>
	[Proto(value=-22002,description="抽奖")]
	[ProtoContract]
	public class LotteryDrawResponse
    {
        /// <summary>
        ///  抽奖类型1,2,3
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public int type;
        /// <summary>
        ///  是否单抽/false十连
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
        public bool once;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RewardInfo rewardInfo;
        /// <summary>
        ///  (仅当次抽取是免费单抽时有效)下次免费抽刷新时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
        public long nextFreeTime;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(5, IsRequired = false)]
        public int baseNumb;
    }
}