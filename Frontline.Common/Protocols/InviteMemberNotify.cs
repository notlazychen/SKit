using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收到邀请 协议:-1309
    /// </summary>
	[Proto(value=-1309,description="收到邀请")]
	[ProtoContract]
	public class InviteMemberNotify
	{
        /// <summary>
        ///  玩法类型
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int diff;
        /// <summary>
        ///  房间号
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string roomId;
        /// <summary>
        ///  邀请者
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public MemberInfo member;

	}
}