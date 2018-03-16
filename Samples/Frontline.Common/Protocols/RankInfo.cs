using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RankInfo
	{
        /// <summary>
        ///  排行榜成绩
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int score;
        /// <summary>
        ///  排名
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int rank;
        /// <summary>
        ///  名字
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  军团名
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string legionName;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int level;
        /// <summary>
        ///  power
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int power;

	}
}