using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 军团商店商品
    /// </summary>
	[ProtoContract]
	public class LegionShopCommodityInfo
    {
        /// <summary>
        ///  商品ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  道具ID
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int item_id;
        /// <summary>
        ///  道具数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int count;
        /// <summary>
        ///  货币数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int res_cnt;
        /// <summary>
        ///  货币类型
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int res_type;
        /// <summary>
        ///  限购数量
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int limit_cnt;
        /// <summary>
        /// 排序
        /// </summary>
        [ProtoMember(7, IsRequired = false)]
        public int order;
        /// <summary>
        /// 军团等级
        /// </summary>
        [ProtoMember(8, IsRequired = false)]
        public int lv;
    }
}