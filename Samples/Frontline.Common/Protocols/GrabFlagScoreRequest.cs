using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 积分奖励请求 协议:146
    /// </summary>
	[Proto(value=146,description="积分奖励请求")]
	[ProtoContract]
	public class GrabFlagScoreRequest
	{
        /// <summary>
        ///  角色Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}