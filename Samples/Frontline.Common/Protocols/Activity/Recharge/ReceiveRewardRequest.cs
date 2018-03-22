using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取奖励 协议:1203
    /// </summary>
	[Proto(value=1203,description="领取奖励")]
	[ProtoContract]
	public class ReceiveRewardRequest
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