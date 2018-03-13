using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收到公会私信 协议:-818
    /// </summary>
	[Proto(value=-818,description="收到公会私信")]
	[ProtoContract]
	public class GuildMessageNotify
	{
        /// <summary>
        ///  私信
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public GuildMessageInfo msg;
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