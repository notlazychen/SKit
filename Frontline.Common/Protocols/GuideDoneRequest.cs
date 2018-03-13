using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 引导上报 协议:102
    /// </summary>
	[Proto(value=102,description="引导上报")]
	[ProtoContract]
	public class GuideDoneRequest
	{
        /// <summary>
        ///  引导步骤index
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public float gindex;

	}
}