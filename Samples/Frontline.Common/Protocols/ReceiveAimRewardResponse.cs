using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取目标奖励返回 协议:-715
    /// </summary>
	[Proto(value=-715,description="领取目标奖励返回")]
	[ProtoContract]
	public class ReceiveAimRewardResponse
	{
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int diamond;
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