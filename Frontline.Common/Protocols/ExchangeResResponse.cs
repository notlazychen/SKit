using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 交换资源返回 协议:-21
    /// </summary>
	[Proto(value=-21,description="交换资源返回")]
	[ProtoContract]
	public class ExchangeResResponse
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
        ///  剩余的钻石数量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  使用的道具Id
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  剩余的道具数量
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int itemCnt;
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