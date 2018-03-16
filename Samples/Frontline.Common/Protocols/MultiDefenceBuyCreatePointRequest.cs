using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）抢滩保卫战，购买造兵点 协议:651
    /// </summary>
	[Proto(value=651,description="（战斗服）抢滩保卫战，购买造兵点")]
	[ProtoContract]
	public class MultiDefenceBuyCreatePointRequest
	{
        /// <summary>
        ///  购买点数
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int buyPoint;

	}
}