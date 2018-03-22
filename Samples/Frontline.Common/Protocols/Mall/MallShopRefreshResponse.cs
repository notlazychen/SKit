using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 刷新结果 协议:-137
    /// </summary>
	[Proto(value=-137,description="刷新结果")]
	[ProtoContract]
	public class MallShopRefreshResponse
	{
        /// <summary>
        ///  商品信息
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<MallShopInfo> shops;
        /// <summary>
        ///  商店类型
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
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