using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 答复邀请 协议:-1310
    /// </summary>
	[Proto(value=-1310,description="答复邀请")]
	[ProtoContract]
	public class ReplyInvitationResponse
	{
        /// <summary>
        ///  如果同意并且成功的话会有房间信息
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RoomInfo room;
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