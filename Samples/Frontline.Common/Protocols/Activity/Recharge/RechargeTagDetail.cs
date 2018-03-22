using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RechargeTagDetail
	{
        /// <summary>
        ///  活动类型(1.钻石购买 2.首充礼包 3.每日特惠 4.超值礼包 12.尊享卡)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  活动
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<ActivityInfo> activities;
        /// <summary>
        ///  限时礼包活动
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<LimitGiftInfo> gifts;

	}
}