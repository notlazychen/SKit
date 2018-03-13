using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 上传战斗结果获得奖励 协议:-47
    /// </summary>
	[Proto(value=-47,description="上传战斗结果获得奖励")]
	[ProtoContract]
	public class FBFightResultResponse
	{
        /// <summary>
        ///  关卡ID
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  星级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int star;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<FightUnitInfo> units;
        /// <summary>
        ///  玩家经验
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  玩家等级
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int lv;
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