using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取宝箱 协议:-77
    /// </summary>
	[Proto(value=-77,description="领取宝箱")]
	[ProtoContract]
	public class RecvResistBoxResponse
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  奖励内容
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
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