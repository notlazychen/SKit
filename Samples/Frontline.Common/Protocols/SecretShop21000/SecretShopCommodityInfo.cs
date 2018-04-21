using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 商品信息
    /// </summary>
    [ProtoContract]
    public class SecretShopCommodityInfo
    {
        /// <summary>
        ///  商品id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public int id;
        /// <summary>
        /// 货币类型
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
        public int res_type;
        /// <summary>
        /// 原价
        /// </summary>
        [ProtoMember(3, IsRequired = false)]
        public int original_price;
        /// <summary>
        /// 现价
        /// </summary>
        [ProtoMember(4, IsRequired = false)]
        public int current_price;
        /// <summary>
        /// 限购数量
        /// </summary>
        [ProtoMember(5, IsRequired = false)]
        public int limit_cnt;
        /// <summary>
        /// 道具id
        /// </summary>
        [ProtoMember(6, IsRequired = false)]
        public int item_id;
        /// <summary>
        /// 道具数量
        /// </summary>
        [ProtoMember(7, IsRequired = false)]
        public int item_cnt;
        [ProtoMember(8, IsRequired = false)]
        public int vip;
    }
}