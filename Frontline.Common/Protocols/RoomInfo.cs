using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RoomInfo
	{
        /// <summary>
        ///  玩法类型 1天梯，2抢滩，3单人匹配
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int diff;
        /// <summary>
        ///  房间id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string roomId;
        /// <summary>
        ///  队员信息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<MemberInfo> members;
        /// <summary>
        ///  房间密码
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string password;
        /// <summary>
        ///  创建时间
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public long createTime;

	}
}