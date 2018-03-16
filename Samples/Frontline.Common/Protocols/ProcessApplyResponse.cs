using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 处理入党申请 协议:-355
    /// </summary>
	[Proto(value=-355,description="处理入党申请")]
	[ProtoContract]
	public class ProcessApplyResponse
	{
        /// <summary>
        ///  申请id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否通过
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool pass;
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