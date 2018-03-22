using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求进入房间 协议:1304
    /// </summary>
	[Proto(value=1304,description="请求进入房间")]
	[ProtoContract]
	public class EnterRoomRequest
	{
        /// <summary>
        ///  房间id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string roomId;
        /// <summary>
        ///  输入的密码（如果有密码的话）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string password;

	}
}