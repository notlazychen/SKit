using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 邀请成员 协议:-1308
    /// </summary>
	[Proto(value=-1308,description="邀请成员")]
	[ProtoContract]
	public class InviteMemberResponse
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
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