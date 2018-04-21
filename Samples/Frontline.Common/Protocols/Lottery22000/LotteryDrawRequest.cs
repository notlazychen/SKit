using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 抽奖
    /// </summary>
	[Proto(value=22002,description="抽奖")]
	[ProtoContract]
	public class LotteryDrawRequest
	{
        /// <summary>
        ///  抽奖类型1,2,3
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  是否单抽/false十连
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool once;

	}
}