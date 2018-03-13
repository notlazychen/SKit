using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取周常宝箱 协议:-913
    /// </summary>
	[Proto(value=-913,description="领取周常宝箱")]
	[ProtoContract]
	public class RecvWeekBoxResponse
	{
        /// <summary>
        ///  领取的宝箱id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  reward
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