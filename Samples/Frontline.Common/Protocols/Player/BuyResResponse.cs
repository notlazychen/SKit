using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买资源 协议:-22
    /// </summary>
	[Proto(value=-22,description="购买资源")]
	[ProtoContract]
	public class BuyResResponse
	{
        /// <summary>
        ///  购买的资源类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  获得的资源数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int count;
        /// <summary>
        ///  花费的钻石数量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int cost;
        /// <summary>
        ///  下次购买所需花费
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int costNext;
        /// <summary>
        ///  剩余的购买次数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int timesRemain;
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