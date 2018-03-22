using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 夺旗战斗结束 协议:143
    /// </summary>
	[Proto(value=143,description="夺旗战斗结束")]
	[ProtoContract]
	public class GrabFlagBattleChallengeOverRequest
	{
        /// <summary>
        ///  此次战斗ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string battleId;
        /// <summary>
        ///  消耗的物品的id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<string> usedItems;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<FightUnitInfo> units;

	}
}