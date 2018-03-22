using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求查收所有公会私信 协议:819
    /// </summary>
	[Proto(value=819,description="请求查收所有公会私信")]
	[ProtoContract]
	public class GuildMessageRequest
	{
        /// <summary>
        ///  本公会ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;

	}
}