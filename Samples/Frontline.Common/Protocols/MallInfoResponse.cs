using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 商城详情 协议:-130
    /// </summary>
	[Proto(value=-130,description="商城详情")]
	[ProtoContract]
	public class MallInfoResponse
	{
        /// <summary>
        ///  商品列表
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<MallShopInfo> items;
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