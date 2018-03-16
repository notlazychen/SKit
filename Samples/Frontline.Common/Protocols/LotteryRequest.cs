using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 抽奖 协议:906
    /// </summary>
	[Proto(value=906,description="抽奖")]
	[ProtoContract]
	public class LotteryRequest
	{
        /// <summary>
        ///  1金币2钻石
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int mode;
        /// <summary>
        ///  1单抽2十连
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int method;

	}
}