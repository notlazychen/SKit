using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求购买夺旗战挑战次数 协议:141
    /// </summary>
	[Proto(value=141,description="请求购买夺旗战挑战次数")]
	[ProtoContract]
	public class BuyGrabFlagChallengeTimesRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}