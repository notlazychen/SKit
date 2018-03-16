using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取在线奖励 协议:712
    /// </summary>
	[Proto(value=712,description="领取在线奖励")]
	[ProtoContract]
	public class RecvOnlineRewardRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}