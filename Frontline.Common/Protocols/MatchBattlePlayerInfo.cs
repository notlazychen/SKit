using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MatchBattlePlayerInfo
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  名字
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string name;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  阵容
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<UnitInfo> units;
        /// <summary>
        ///  技能
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<SkillInfo> skills;
        /// <summary>
        ///  出生点
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int position;
        /// <summary>
        ///  所属队伍1,2
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int group;
        /// <summary>
        ///  vip
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  level
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int level;
        /// <summary>
        ///  天梯信息（仅天梯赛有）
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public S2SLadderInfo ladderInfo;
        /// <summary>
        ///  服务器名字
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public string serName;
        /// <summary>
        ///  diamond
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  正为连胜,负为连败
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int comboWin;

	}
}