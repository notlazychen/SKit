using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 设置密码 协议:-1303
    /// </summary>
	[Proto(value=-1303,description="设置密码")]
	[ProtoContract]
	public class SetRoomPasswordResponse
	{
        /// <summary>
        ///  密码
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string password;
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