using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求挑战 协议:144
    /// </summary>
	[Proto(value=144,description="请求挑战")]
	[ProtoContract]
	public class GrabFlagBattleChallengeRequest
	{
        /// <summary>
        ///  对手的pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string adversaryPid;

	}
}