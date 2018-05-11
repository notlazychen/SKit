using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买军团商店物品 协议:23002
    /// </summary>
	[Proto(value=23002,description= "购买军团商店物品")]
	[ProtoContract]
	public class BuyLegionShopItemRequest
	{
        /// <summary>
        ///  商品id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        /// 购买数量
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
        public int count=1;
    }
}