using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买运输副本挑战次数 协议:-623
    /// </summary>
	[Proto(value=-623,description="购买运输副本挑战次数")]
	[ProtoContract]
	public class BuyTransportTimesResponse
	{
        /// <summary>
        ///  购买次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int buyTimes;
        /// <summary>
        ///  已挑战次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int usedNumber;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diamond;
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