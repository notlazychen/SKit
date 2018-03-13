using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）发送全部数据 协议:-506
    /// </summary>
	[Proto(value=-506,description="（战斗服）发送全部数据")]
	[ProtoContract]
	public class B2CBattleFieldData
	{
        /// <summary>
        ///  玩家数据
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<PVPPlayerInfo> playerInfos;
        /// <summary>
        ///  旗帜信息
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<PVPFlag> flags;
        /// <summary>
        ///  怪物
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<BattleMonsterInfo> monsters;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}