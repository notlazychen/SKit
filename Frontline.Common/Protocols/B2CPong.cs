using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）Pong 协议:-507
    /// </summary>
	[Proto(value=-507,description="（战斗服）Pong")]
	[ProtoContract]
	public class B2CPong
	{
        /// <summary>
        ///  发出时间
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public long sendTime;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}