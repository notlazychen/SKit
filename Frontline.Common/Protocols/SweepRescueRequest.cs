using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 扫荡雪地营救 协议:225
    /// </summary>
	[Proto(value=225,description="扫荡雪地营救")]
	[ProtoContract]
	public class SweepRescueRequest
	{
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int difficulty;

	}
}