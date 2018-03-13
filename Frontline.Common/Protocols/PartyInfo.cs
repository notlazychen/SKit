using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PartyInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string name;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  军团长名字
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string leaderName;
        /// <summary>
        ///  宗旨
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string note;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int level;
        /// <summary>
        ///  当前经验
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  下一级所需经验
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int next_exp;
        /// <summary>
        ///  当前人数
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int count;
        /// <summary>
        ///  最大人数
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int max;
        /// <summary>
        ///  是否已经申请过了
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public bool applied;
        /// <summary>
        ///  简称
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public string shortName;
        /// <summary>
        ///  是否需要审核
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public bool check;

	}
}