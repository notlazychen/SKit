using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵种休整立即完成 协议:-831
    /// </summary>
	[Proto(value=-831,description="兵种休整立即完成")]
	[ProtoContract]
	public class GVGRestFinishResponse
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