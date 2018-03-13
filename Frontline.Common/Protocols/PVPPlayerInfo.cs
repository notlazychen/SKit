using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVPPlayerInfo
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  分数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int playerScore;
        /// <summary>
        ///  造兵点数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int playerCreateArmyPoint;
        /// <summary>
        ///  作战单位
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<PVPBattleUnitInfo> unitsInfo;

	}
}