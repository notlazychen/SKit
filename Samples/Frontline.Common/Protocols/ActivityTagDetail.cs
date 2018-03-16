using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ActivityTagDetail
	{
        /// <summary>
        ///  活动类型(1连续登录，2充值返利，3冲级奖励，4首充礼包, 8七日登陆)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  连续登录最后签到的时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long lastRecvDay;
        /// <summary>
        ///  活动
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<ActivityInfo> activities;
        /// <summary>
        ///  是否购买过成长
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool boughtCZ;
        /// <summary>
        ///  是否弹窗
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int popup;
        /// <summary>
        ///  实际走过的天数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int actually_day;
        /// <summary>
        ///  七日登陆签到天数
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int seven_day;
        /// <summary>
        ///  已补签次数
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int replenishedTime;
        /// <summary>
        ///  当天签到次数
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int now_signTime;

	}
}