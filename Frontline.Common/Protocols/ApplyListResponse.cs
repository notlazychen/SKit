using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 入党申请列表 协议:-354
    /// </summary>
	[Proto(value=-354,description="入党申请列表")]
	[ProtoContract]
	public class ApplyListResponse
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  入党申请列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<ApplyInfo> applies;
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