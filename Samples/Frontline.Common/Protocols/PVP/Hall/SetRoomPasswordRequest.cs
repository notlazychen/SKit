using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 设置密码 协议:1303
    /// </summary>
	[Proto(value=1303,description="设置密码")]
	[ProtoContract]
	public class SetRoomPasswordRequest
	{
        /// <summary>
        ///  密码
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string password;

	}
}