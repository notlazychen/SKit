using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战内）发送公会私信 协议:-817
    /// </summary>
	[Proto(value=-817,description="（公会战内）发送公会私信")]
	[ProtoContract]
	public class SendGuildMessageResponse
	{
        /// <summary>
        ///  公会Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string gid;
        /// <summary>
        ///  消息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string msg;
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