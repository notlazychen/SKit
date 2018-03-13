using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MemberInfo
	{
        /// <summary>
        ///  玩家姓名
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string name;
        /// <summary>
        ///  玩家头像
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  vip
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  玩家等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int level;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int power;
        /// <summary>
        ///  房主
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public bool owner;
        /// <summary>
        ///  是否已邀请
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public bool invited;

	}
}