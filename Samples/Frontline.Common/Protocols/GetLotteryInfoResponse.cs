using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取抽奖相关信息 协议:-905
    /// </summary>
	[Proto(value=-905,description="获取抽奖相关信息")]
	[ProtoContract]
	public class GetLotteryInfoResponse
	{
        /// <summary>
        ///  今日金币抽次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int goldUsedNumb;
        /// <summary>
        ///  下次免费金币抽刷新时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long goldFreeNextTime;
        /// <summary>
        ///  剩余出金币抽保底奖励的次数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int goldBaseNumb;
        /// <summary>
        ///  金币免费次数
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int goldFreeNumb;
        /// <summary>
        ///  今日钻石抽次数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int diamondUsedNumb;
        /// <summary>
        ///  下次免费钻石抽时间
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public long diamondFreeNextTime;
        /// <summary>
        ///  剩余出钻石保底奖励的次数
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int diamondBaseNumb;
        /// <summary>
        ///  钻石免费次数
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int diamondFreeNumb;
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