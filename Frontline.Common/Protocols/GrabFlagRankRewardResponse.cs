using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 夺旗排名奖励返回 协议:-149
    /// </summary>
	[Proto(value=-149,description="夺旗排名奖励返回")]
	[ProtoContract]
	public class GrabFlagRankRewardResponse
	{
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<GrabFlagRankRewardInfo> rewardInfos;
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