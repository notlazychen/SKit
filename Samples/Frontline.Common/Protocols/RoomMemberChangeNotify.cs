using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 成员信息变更推送 协议:-1312
    /// </summary>
	[Proto(value=-1312,description="成员信息变更推送")]
	[ProtoContract]
	public class RoomMemberChangeNotify
	{
        /// <summary>
        ///  1进入，2离开，3变更房主
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int op;
        /// <summary>
        ///  member
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public MemberInfo member;
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