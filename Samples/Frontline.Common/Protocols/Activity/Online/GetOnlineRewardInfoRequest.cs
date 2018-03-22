using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 在线奖励信息 协议:711
    /// </summary>
	[Proto(value=711,description="在线奖励信息")]
	[ProtoContract]
	public class GetOnlineRewardInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}