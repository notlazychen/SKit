using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 留言板 协议:361
    /// </summary>
	[Proto(value=361,description="留言板")]
	[ProtoContract]
	public class PartyBBSRequest
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string party;

	}
}