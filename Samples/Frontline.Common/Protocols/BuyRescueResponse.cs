using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买雪地营救次数 协议:-224
    /// </summary>
	[Proto(value=-224,description="购买雪地营救次数")]
	[ProtoContract]
	public class BuyRescueResponse
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
		public int playedNumb;
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