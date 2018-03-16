using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）踢出战斗 协议:-510
    /// </summary>
	[Proto(value=-510,description="（战斗服）踢出战斗")]
	[ProtoContract]
	public class B2CKick
	{
        /// <summary>
        ///  原因 1同步次数过多
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int reason;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}