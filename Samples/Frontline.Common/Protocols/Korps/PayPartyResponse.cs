using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 交党费 协议:-358
    /// </summary>
	[Proto(value=-358,description="交党费")]
	[ProtoContract]
	public class PayPartyResponse
	{
        /// <summary>
        ///  log
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public ContriLogInfo log;
        /// <summary>
        ///  当日贡献次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int cur;
        /// <summary>
        ///  rewardInfo
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo rewardInfo;
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