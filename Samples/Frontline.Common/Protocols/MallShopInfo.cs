using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MallShopInfo
	{
        /// <summary>
        ///  商店分类
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  商品ID
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int id;
        /// <summary>
        ///  道具ID
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int item_id;
        /// <summary>
        ///  道具数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int count;
        /// <summary>
        ///  货币数量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int res_cnt;
        /// <summary>
        ///  货币类型
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int res_type;
        /// <summary>
        ///  限购数量
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int limit_cnt;

	}
}