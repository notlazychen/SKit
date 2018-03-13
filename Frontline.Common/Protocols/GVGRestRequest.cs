using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵种休整 协议:825
    /// </summary>
	[Proto(value=825,description="兵种休整")]
	[ProtoContract]
	public class GVGRestRequest
	{
        /// <summary>
        ///  兵种Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string unitId;

	}
}