using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// ping协议，保活 协议:7
    /// </summary>
	[Proto(value=7,description="ping协议，保活")]
	[ProtoContract]
	public class Ping
	{
        /// <summary>
        ///  客户端的时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}