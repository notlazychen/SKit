using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取抽奖相关信息 协议:-905
    /// </summary>
	[Proto(value=-22001,description="获取抽奖相关信息")]
	[ProtoContract]
	public class LotteryInfoResponse
	{
        /// <summary>
        /// 抽奖类型列表
        /// </summary>
        [ProtoMember(1, IsRequired = false)]
        public List<LotteryInfo> LotteryInfos;
    }

    /// <summary>
    /// 抽奖类型信息
    /// </summary>
    [ProtoContract]
    public class LotteryInfo
    {
        /// <summary>
        ///  下次免费抽刷新时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public long nextFreeTime;
        /// <summary>
        /// 抽奖结束时间
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
        public long endTime;
        /// <summary>
        ///  消耗道具Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
        public int itemId;
        /// <summary>
        ///  保底剩余次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
        public int baseNumb;
    }
}