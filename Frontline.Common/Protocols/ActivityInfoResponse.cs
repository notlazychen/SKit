using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 活动数据返回 协议:-701
    /// </summary>
	[Proto(value=-701,description="活动数据返回")]
	[ProtoContract]
	public class ActivityInfoResponse
	{
        /// <summary>
        ///  detail
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public ActivityTagDetail detail;
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