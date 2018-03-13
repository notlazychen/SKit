using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （游戏服）抢滩保卫战，战斗结束 协议:-652
    /// </summary>
	[Proto(value=-652,description="（游戏服）抢滩保卫战，战斗结束")]
	[ProtoContract]
	public class MultiDefenceBattleOverNotify
	{
        /// <summary>
        ///  是否胜利
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  参战者
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<MultiDefencePlayerInfo> players;

	}
}