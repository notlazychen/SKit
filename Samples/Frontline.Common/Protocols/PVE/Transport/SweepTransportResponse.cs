using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 扫荡运输副本 协议:-625
    /// </summary>
	[Proto(value=-625,description="扫荡运输副本")]
	[ProtoContract]
	public class SweepTransportResponse
	{
        /// <summary>
        ///  rewardInfo
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RewardInfo rewardInfo;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int difficultDegree;
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