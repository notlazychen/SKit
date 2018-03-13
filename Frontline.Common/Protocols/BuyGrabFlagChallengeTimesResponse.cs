using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买夺旗战挑战次数返回 协议:-141
    /// </summary>
	[Proto(value=-141,description="购买夺旗战挑战次数返回")]
	[ProtoContract]
	public class BuyGrabFlagChallengeTimesResponse
	{
        /// <summary>
        ///  剩余次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int remainChallengeTimes;
        /// <summary>
        ///  已购买次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int buyTimes;
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