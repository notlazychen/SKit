using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 进入匹配 协议:5000
    /// </summary>
	[Proto(value=5000,description="进入匹配")]
	[ProtoContract]
	public class S2SMatchRequest
	{
        /// <summary>
        ///  info
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public MatchBattlePlayerInfo info;
        /// <summary>
        ///  type
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int type;
        /// <summary>
        ///  diff
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int diff;

	}
}