using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class FlagBreakRankReward
	{
        /// <summary>
        ///  奖励对应的排名
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int rank;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public RewardInfo reward;

	}
}