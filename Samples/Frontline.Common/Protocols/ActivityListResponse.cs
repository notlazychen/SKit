using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 活动类型列表 协议:-700
    /// </summary>
	[Proto(value=-700,description="活动类型列表")]
	[ProtoContract]
	public class ActivityListResponse
	{
        /// <summary>
        ///  活动类型列表
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<ActivityTagInfo> tagInfos;
        /// <summary>
        ///  当前最高战力
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int now_maxPower;
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