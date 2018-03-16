using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 合成物品 协议:-34
    /// </summary>
	[Proto(value=-34,description="合成物品")]
	[ProtoContract]
	public class MergeItemResponse
	{
        /// <summary>
        ///  物品id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  物品剩余的堆叠（0表示已经没有了）
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int remain;
        /// <summary>
        ///  剩余金币
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  合成的物品Id
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int mergedItemId;
        /// <summary>
        ///  合成的物品数量
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int mergedItemCount;
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