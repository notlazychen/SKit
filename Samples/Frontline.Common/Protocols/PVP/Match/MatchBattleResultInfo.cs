using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MatchBattleResultInfo
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  win
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  原因
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int reason;
        /// <summary>
        ///  vip
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  level
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int level;
        /// <summary>
        ///  name
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string name;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  serName
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string serName;
        /// <summary>
        ///  score
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int score;
        /// <summary>
        ///  消费的钻石
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int costDiamond;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public RewardInfo rewardInfo;
        /// <summary>
        ///  天梯信息（仅天梯赛有）
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public S2SLadderInfo ladderInfo;
        /// <summary>
        ///  消耗掉的技能
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public List<int> usedSkills;
        /// <summary>
        ///  登场过的兵种
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public List<PVPUnitInfo> units;
        /// <summary>
        ///  死亡兵种
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public List<string> deadUnits;
        /// <summary>
        ///  占领的据点
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int capture;

	}
}