using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 军团商店详情 协议:-23001
    /// </summary>
	[Proto(value=-23001,description= "军团商店详情")]
	[ProtoContract]
	public class LegionShopInfoResponse
	{
        /// <summary>
        ///  商品列表
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<LegionShopCommodityInfo> commodities;
	}
}