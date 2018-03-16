using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）造兵 协议:-504
    /// </summary>
	[Proto(value=-504,description="（战斗服）造兵")]
	[ProtoContract]
	public class B2CCreateArmy
	{
        /// <summary>
        ///  造兵的玩家
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  剩余点数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int remainPoint;
        /// <summary>
        ///  出生点
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int bornPlace;
        /// <summary>
        ///  生产出来的兵
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public UnitInfo unitInfo;
        /// <summary>
        ///  生产出来的怪物
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public MonsterInfo monsterInfo;
        /// <summary>
        ///  本场战斗创建该兵的编号（用于给单个小兵编号
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int teamIndex;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}