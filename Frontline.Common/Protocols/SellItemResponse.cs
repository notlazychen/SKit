using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 出售物品 协议:-33
    /// </summary>
	[Proto(value=-33,description="出售物品")]
	[ProtoContract]
	public class SellItemResponse
	{
        /// <summary>
        ///  物品id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  剩余数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int remain;
        /// <summary>
        ///  获取金币
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int gold;
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