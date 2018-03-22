using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 夺旗排名奖励 协议:149
    /// </summary>
	[Proto(value=149,description="夺旗排名奖励")]
	[ProtoContract]
	public class GrabFlagRankRewardRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}