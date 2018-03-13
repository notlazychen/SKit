using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取活动奖励 协议:702
    /// </summary>
	[Proto(value=702,description="领取活动奖励")]
	[ProtoContract]
	public class ReceiveActivityRewardRequest
	{
        /// <summary>
        ///  活动类型
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  活动Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;

	}
}