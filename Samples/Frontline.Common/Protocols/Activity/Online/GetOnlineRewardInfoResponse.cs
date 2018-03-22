using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 在线奖励信息 协议:-711
    /// </summary>
	[Proto(value=-711,description="在线奖励信息")]
	[ProtoContract]
	public class GetOnlineRewardInfoResponse
	{
        /// <summary>
        ///  可领取的时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long recvTime;
        /// <summary>
        ///  reward
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo reward;
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