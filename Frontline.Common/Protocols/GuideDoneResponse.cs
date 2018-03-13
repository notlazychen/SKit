using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 引导完成返回 协议:-102
    /// </summary>
	[Proto(value=-102,description="引导完成返回")]
	[ProtoContract]
	public class GuideDoneResponse
	{
        /// <summary>
        ///  引导步骤index
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public float gindex;
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