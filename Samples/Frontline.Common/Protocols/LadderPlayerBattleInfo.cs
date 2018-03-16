using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class LadderPlayerBattleInfo
	{
        /// <summary>
        ///  是否胜利
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public bool win;
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  name
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string name;
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int ladderScore;
        /// <summary>
        ///  vip
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  level
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int level;
        /// <summary>
        ///  服务器名字
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string serName;
        /// <summary>
        ///  加减法
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int deltaScore;
        /// <summary>
        ///  军衔
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int militaryRank;
        /// <summary>
        ///  登场过的兵种策划ID
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public List<int> units;

	}
}