using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 抽奖 协议:-906
    /// </summary>
	[Proto(value=-906,description="抽奖")]
	[ProtoContract]
	public class LotteryResponse
	{
        /// <summary>
        ///  1金币2钻石
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int mode;
        /// <summary>
        ///  1单抽2十连
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int method;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo rewardInfo;
        /// <summary>
        ///  剩余金币
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  今日金币抽次数
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int goldUsedNumb;
        /// <summary>
        ///  下次免费金币抽刷新时间
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public long goldFreeNextTime;
        /// <summary>
        ///  剩余出金币抽保底奖励的次数
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int goldBaseNumb;
        /// <summary>
        ///  金币免费次数
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int goldFreeNumb;
        /// <summary>
        ///  今日钻石抽次数
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int diamondUsedNumb;
        /// <summary>
        ///  下次免费钻石抽时间
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public long diamondFreeNextTime;
        /// <summary>
        ///  剩余出钻石保底奖励的次数
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int diamondBaseNumb;
        /// <summary>
        ///  钻石免费次数
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
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