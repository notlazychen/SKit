using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ActivityInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  开始时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long startTime;
        /// <summary>
        ///  结束时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long endTime;
        /// <summary>
        ///  可领取等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int level;
        /// <summary>
        ///  可领取登录天数
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int day;
        /// <summary>
        ///  双倍VIP，0则无双倍
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  标题
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string title;
        /// <summary>
        ///  内容
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string content;
        /// <summary>
        ///  是否已领取
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public bool received;
        /// <summary>
        ///  是否已充值
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public bool recharged;
        /// <summary>
        ///  返利系数
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public float fanliK;
        /// <summary>
        ///  解锁兵种
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int unitId;
        /// <summary>
        ///  月卡到期时间
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public long cardEndTime;
        /// <summary>
        ///  最后一次月卡领取时间
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public long cardLastRecvTime;
        /// <summary>
        ///  累计充值金额
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public float rechargeDiamond;
        /// <summary>
        ///  累计消费钻石目标
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int consumeDiamond;
        /// <summary>
        ///  当前消费钻石
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int now_consumeDiamond;
        /// <summary>
        ///  玩家所需战力
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public int power;
        /// <summary>
        ///  收集物品id
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public int collect_id;
        /// <summary>
        ///  收集物品数量
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public int collect_cnt;
        /// <summary>
        ///  当前收集物品数量
        /// </summary>
		[ProtoMember(22, IsRequired = false)]
		public int now_collect;
        /// <summary>
        ///  尊享卡类型
        /// </summary>
		[ProtoMember(23, IsRequired = false)]
		public int card_type;
        /// <summary>
        ///  商品id
        /// </summary>
		[ProtoMember(24, IsRequired = false)]
		public int product_id;
        /// <summary>
        ///  24小时登陆可领取时间
        /// </summary>
		[ProtoMember(25, IsRequired = false)]
		public long twentyFourRecvTime;
        /// <summary>
        ///  价格
        /// </summary>
		[ProtoMember(26, IsRequired = false)]
		public float price;
        /// <summary>
        ///  剩余购买次数
        /// </summary>
		[ProtoMember(27, IsRequired = false)]
		public int times;

	}
}