using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵种休整立即完成 协议:831
    /// </summary>
	[Proto(value=831,description="兵种休整立即完成")]
	[ProtoContract]
	public class GVGRestFinishRequest
	{
        /// <summary>
        ///  兵种Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string unitId;

	}
}