using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 扫荡运输玩法 协议:625
    /// </summary>
	[Proto(value=625,description="扫荡运输玩法")]
	[ProtoContract]
	public class SweepTransportRequest
	{
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int difficultDegree;

	}
}