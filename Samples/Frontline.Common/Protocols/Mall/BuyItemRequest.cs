using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买物品 协议:131
    /// </summary>
	[Proto(value=131,description="购买物品")]
	[ProtoContract]
	public class BuyItemRequest
	{
        /// <summary>
        ///  商品id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  商品类型
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;
        /// <summary>
        /// 购买数量
        /// </summary>
        [ProtoMember(3, IsRequired = false)]
        public int count;
    }
}