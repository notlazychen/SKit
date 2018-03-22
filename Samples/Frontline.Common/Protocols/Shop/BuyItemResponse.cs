using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买物品 协议:-131
    /// </summary>
	[Proto(value=-131,description="购买物品")]
	[ProtoContract]
	public class BuyItemResponse
	{
        /// <summary>
        ///  商品id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  商品分类
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
        /// <summary>
        ///  剩余的货币
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int remain;
        /// <summary>
        ///  货币类型
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int res_type;
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