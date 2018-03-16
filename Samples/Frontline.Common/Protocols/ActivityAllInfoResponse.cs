using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求全部活动数据 协议:-704
    /// </summary>
	[Proto(value=-704,description="请求全部活动数据")]
	[ProtoContract]
	public class ActivityAllInfoResponse
	{
        /// <summary>
        ///  活动
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<ActivityTagDetail> allInfos;
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