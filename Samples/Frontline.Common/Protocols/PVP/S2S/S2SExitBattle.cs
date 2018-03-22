using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 离开战场 协议:5006
    /// </summary>
	[Proto(value=5006,description="离开战场")]
	[ProtoContract]
	public class S2SExitBattle
	{
        /// <summary>
        ///  战斗结果
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<MatchBattleResultInfo> resultInfos;
        /// <summary>
        ///  type
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int type;
        /// <summary>
        ///  diff
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int diff;
        /// <summary>
        ///  battleOverTime
        /// </summary>
		[ProtoMember(4, IsRequired = true)]
		public long battleOverTime;
        /// <summary>
        ///  battleUsedTime
        /// </summary>
		[ProtoMember(5, IsRequired = true)]
		public long battleUsedTime;
        /// <summary>
        ///  接受者
        /// </summary>
		[ProtoMember(6, IsRequired = true)]
		public string toPid;
        /// <summary>
        ///  reason
        /// </summary>
		[ProtoMember(7, IsRequired = true)]
		public int reason;

	}
}