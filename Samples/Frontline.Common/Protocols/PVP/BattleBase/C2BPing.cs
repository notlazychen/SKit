using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）PING 协议:507
    /// </summary>
	[Proto(value=507,description="（战斗服）PING")]
	[ProtoContract]
	public class C2BPing
	{
        /// <summary>
        ///  发出时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long sendTime;

	}
}