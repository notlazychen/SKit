using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵种休整 协议:-825
    /// </summary>
	[Proto(value=-825,description="兵种休整")]
	[ProtoContract]
	public class GVGRestResponse
	{
        /// <summary>
        ///  兵种
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public GVGUnitInfo unit;
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