using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 邀请成员 协议:1308
    /// </summary>
	[Proto(value=1308,description="邀请成员")]
	[ProtoContract]
	public class InviteMemberRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}