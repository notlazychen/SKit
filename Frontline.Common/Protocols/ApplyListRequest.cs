using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 入党申请列表 协议:354
    /// </summary>
	[Proto(value=354,description="入党申请列表")]
	[ProtoContract]
	public class ApplyListRequest
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}