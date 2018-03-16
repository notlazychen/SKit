using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战内）请求公会战战场信息 协议:800
    /// </summary>
	[Proto(value=800,description="（公会战内）请求公会战战场信息")]
	[ProtoContract]
	public class GVGMapRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}