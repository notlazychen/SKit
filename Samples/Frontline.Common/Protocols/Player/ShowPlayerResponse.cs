using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看玩家信息 协议:-152
    /// </summary>
	[Proto(value=-152,description="查看玩家信息")]
	[ProtoContract]
	public class ShowPlayerResponse
	{
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int level;
        /// <summary>
        ///  军团名
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string legionName;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  vip
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  是否好友
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public bool isfriend;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int power;
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