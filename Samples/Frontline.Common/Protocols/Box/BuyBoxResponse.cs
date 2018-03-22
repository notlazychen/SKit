using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买宝箱 协议:-136
    /// </summary>
	[Proto(value=-136,description="购买宝箱")]
	[ProtoContract]
	public class BuyBoxResponse
	{
        /// <summary>
        ///  宝箱id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  宝箱奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int remain;
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