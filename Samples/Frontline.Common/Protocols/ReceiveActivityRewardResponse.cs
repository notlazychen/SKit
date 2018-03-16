using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取活动奖励返回 协议:-702
    /// </summary>
	[Proto(value=-702,description="领取活动奖励返回")]
	[ProtoContract]
	public class ReceiveActivityRewardResponse
	{
        /// <summary>
        ///  reward
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int id;
        /// <summary>
        ///  type
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int type;
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
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