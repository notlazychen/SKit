using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 挑战周常关卡 协议:-912
    /// </summary>
	[Proto(value=-912,description="挑战周常关卡")]
	[ProtoContract]
	public class WeekBattleEndResponse
	{
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int score;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<FightUnitInfo> units;
        /// <summary>
        ///  本周挑战天数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int battleDays;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int diff;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}