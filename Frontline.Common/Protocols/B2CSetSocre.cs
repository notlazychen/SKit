using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）同步分数 协议:-503
    /// </summary>
	[Proto(value=-503,description="（战斗服）同步分数")]
	[ProtoContract]
	public class B2CSetSocre
	{
        /// <summary>
        ///  scores
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<PVPScoreInfo> scores;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}