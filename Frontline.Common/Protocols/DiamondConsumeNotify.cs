using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 累计消费钻石数量推送 协议:-707
    /// </summary>
	[Proto(value=-707,description="累计消费钻石数量推送")]
	[ProtoContract]
	public class DiamondConsumeNotify
	{
        /// <summary>
        ///  累计消费钻石数量
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int diamond;

	}
}