using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 合成物品 协议:34
    /// </summary>
	[Proto(value=34,description="合成物品")]
	[ProtoContract]
	public class MergeItemRequest
	{
        /// <summary>
        ///  物品id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string id;
        /// <summary>
        ///  是否合成全部
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool all;

	}
}