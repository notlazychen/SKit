using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 审核调整 协议:367
    /// </summary>
	[Proto(value=367,description="审核调整")]
	[ProtoContract]
	public class ChangeCheckRequest
	{
        /// <summary>
        ///  是否审核
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool check;

	}
}