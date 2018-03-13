using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查收所有公会私信 协议:-819
    /// </summary>
	[Proto(value=-819,description="查收所有公会私信")]
	[ProtoContract]
	public class GuildMessageResponse
	{
        /// <summary>
        ///  私信集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<GuildMessageInfo> msgs;
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