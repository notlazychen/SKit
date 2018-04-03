using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党员列表 协议:353
    /// </summary>
	[Proto(value=353,description="党员列表")]
	[ProtoContract]
	public class MemberListRequest
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}