using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取目标福利 协议:715
    /// </summary>
	[Proto(value=715,description="领取目标福利")]
	[ProtoContract]
	public class ReceiveAimRewardRequest
	{
        /// <summary>
        ///  活动Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;

	}
}