using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 审核设置 协议:-367
    /// </summary>
	[Proto(value=-367,description="审核设置")]
	[ProtoContract]
	public class ChangerCheckResponse
	{
        /// <summary>
        ///  是否审核
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool check;
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