using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 活动数据返回 协议:-713
    /// </summary>
	[Proto(value=-713,description="活动数据返回")]
	[ProtoContract]
	public class QiRiInfoResponse
	{
        /// <summary>
        ///  detail
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<QiRiWalfareInfo> lists;
        /// <summary>
        ///  活动实际走过的天数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int actually_day;
        /// <summary>
        ///  是否已经加入军团
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool joined;
        /// <summary>
        ///  目标奖励
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<QiRiWalfareInfo> AimReward;
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