using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 挑战周常关卡 协议:912
    /// </summary>
	[Proto(value=912,description="挑战周常关卡")]
	[ProtoContract]
	public class WeekBattleEndRequest
	{
        /// <summary>
        ///  消耗的技能的id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<string> usedItems;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<FightUnitInfo> units;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string token;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diff;

	}
}