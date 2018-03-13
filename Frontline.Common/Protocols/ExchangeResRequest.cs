using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 交换资源 协议:21
    /// </summary>
	[Proto(value=21,description="交换资源")]
	[ProtoContract]
	public class ExchangeResRequest
	{
        /// <summary>
        ///  资源类型
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  用什么道具交换
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  消耗道具数量（如果道具不足，则消耗钻石购买）
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int itemCnt;

	}
}