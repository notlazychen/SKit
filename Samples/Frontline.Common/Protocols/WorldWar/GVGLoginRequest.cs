using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 公会战登录 协议:812
    /// </summary>
	[Proto(value=812,description="公会战登录")]
	[ProtoContract]
	public class GVGLoginRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string token;

	}
}