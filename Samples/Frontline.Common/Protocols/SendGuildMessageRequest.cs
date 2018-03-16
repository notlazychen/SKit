using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 发送公会私信 协议:817
    /// </summary>
	[Proto(value=817,description="发送公会私信")]
	[ProtoContract]
	public class SendGuildMessageRequest
	{
        /// <summary>
        ///  公会Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;
        /// <summary>
        ///  消息
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string msg;

	}
}