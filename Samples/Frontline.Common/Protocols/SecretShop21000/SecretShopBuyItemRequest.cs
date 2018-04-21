using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买神秘商店商品
    /// </summary>
	[Proto(value = 21003, description = "购买神秘商店商品")]
    [ProtoContract]
    public class SecretShopBuyItemRequest
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [ProtoMember(1, IsRequired = false)]
        public int id;
    }
}