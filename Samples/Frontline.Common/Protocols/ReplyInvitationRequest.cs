using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 答复邀请 协议:1310
    /// </summary>
	[Proto(value=1310,description="答复邀请")]
	[ProtoContract]
	public class ReplyInvitationRequest
	{
        /// <summary>
        ///  房间号
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string roomId;
        /// <summary>
        ///  答复 0取消，1同意
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int op;

	}
}