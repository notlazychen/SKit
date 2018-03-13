using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class QiRiWalfareInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  tag
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  可领取登录天数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int day;
        /// <summary>
        ///  是否已领取
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool received;
        /// <summary>
        ///  商品id
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int product_id;
        /// <summary>
        ///  任务类型
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int mission_type;
        /// <summary>
        ///  任务跳转
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int jump;
        /// <summary>
        ///  任务完成进度
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int process;
        /// <summary>
        ///  原价钻石
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  现价钻石
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int discount;
        /// <summary>
        ///  促销文字
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  活动类型
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int type;
        /// <summary>
        ///  礼包价值
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int value;
        /// <summary>
        ///  当前任务进度
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int now_process;
        /// <summary>
        ///  剩余购买次数
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int times;

	}
}