using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵种休整 协议:17
    /// </summary>
	[Proto(value=17,description="兵种休整")]
	[ProtoContract]
	public class BuildUnitRequest
	{
        /// <summary>
        ///  单位id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否立即完成（使用钻石）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool immediately;

	}
}