using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）抢滩保卫战，购买造兵点返回 协议:-651
    /// </summary>
	[Proto(value=-651,description="（战斗服）抢滩保卫战，购买造兵点返回")]
	[ProtoContract]
	public class MultiDefenceBuyCreatePointResponse
	{
        /// <summary>
        ///  剩余造兵点数
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int createPoint;
        /// <summary>
        ///  消耗钻石
        /// </summary>
		[ProtoMember(4, IsRequired = true)]
		public int costDiamond;
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