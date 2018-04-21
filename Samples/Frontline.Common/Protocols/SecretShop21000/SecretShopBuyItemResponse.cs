using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买神秘商店商品
    /// </summary>
	[Proto(value = -21003, description = "购买神秘商店商品")]
    [ProtoContract]
    public class SecretShopBuyItemResponse
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [ProtoMember(1, IsRequired = false)]
        public int id;
        /// <summary>
        /// 获得道具id
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
        public int item_id;
        /// <summary>
        /// 获得道具数量
        /// </summary>
        [ProtoMember(3, IsRequired = false)]
        public int item_cnt;
    }
}