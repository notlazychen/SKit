using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PartyMemberInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int level;
        /// <summary>
        ///  vip等级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  职位
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int career;
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string nickname;
        /// <summary>
        ///  最近一次上线时间
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public long lastLoginTime;
        /// <summary>
        ///  贡献
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public long contri;
        /// <summary>
        ///  阵营
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int camp;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int power;

	}
}