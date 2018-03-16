using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战内）请求公会详情 协议:-814
    /// </summary>
	[Proto(value=-814,description="（公会战内）请求公会详情")]
	[ProtoContract]
	public class GuildDetailResponse
	{
        /// <summary>
        ///  公会Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string gid;
        /// <summary>
        ///  位置Id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string posId;
        /// <summary>
        ///  主堡等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int cityLv;
        /// <summary>
        ///  会长Id
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string leaderPid;
        /// <summary>
        ///  会长名字
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string leaderName;
        /// <summary>
        ///  会长icon
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string leaderIcon;
        /// <summary>
        ///  公会名字
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string name;
        /// <summary>
        ///  公会状态
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int state;
        /// <summary>
        ///  军团荣誉
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int glory;
        /// <summary>
        ///  可驻扎总人数
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int totalGarrison;
        /// <summary>
        ///  当前驻军人数
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int curGarrison;
        /// <summary>
        ///  可能掉落道具
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public List<int> items;
        /// <summary>
        ///  当前耐久
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int HP;
        /// <summary>
        ///  总耐久
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int maxHP;
        /// <summary>
        ///  火力
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int atk;
        /// <summary>
        ///  防御
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int def;
        /// <summary>
        ///  暴击率
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public float crit;
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