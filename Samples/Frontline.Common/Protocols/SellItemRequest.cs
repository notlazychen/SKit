using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 出售物品 协议:33
    /// </summary>
	[Proto(value=33,description="出售物品")]
	[ProtoContract]
	public class SellItemRequest
	{
        /// <summary>
        ///  物品id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  出售数量
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int count;

	}
}