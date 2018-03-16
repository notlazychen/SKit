using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开启战场 协议:5005
    /// </summary>
	[Proto(value=5005,description="开启战场")]
	[ProtoContract]
	public class S2SEnterBattle
	{
        /// <summary>
        ///  players
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<S2SBattlePlayerInfo> players;
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