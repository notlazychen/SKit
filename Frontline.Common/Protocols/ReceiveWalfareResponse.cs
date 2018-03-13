using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 活动数据返回 协议:-714
    /// </summary>
	[Proto(value=-714,description="活动数据返回")]
	[ProtoContract]
	public class ReceiveWalfareResponse
	{
        /// <summary>
        ///  活动类型(1:登录 2:任务 3:钻石抢购 4:一元礼包)
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  活动Id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int id;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  剩余购买次数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int times;
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