using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 扫荡雪地营救返回 协议:-225
    /// </summary>
	[Proto(value=-225,description="扫荡雪地营救返回")]
	[ProtoContract]
	public class SweepRescueResponse
	{
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int difficulty;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo reward;
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