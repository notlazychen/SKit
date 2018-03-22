using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党详情 协议:359
    /// </summary>
	[Proto(value=359,description="党详情")]
	[ProtoContract]
	public class PartyDetailRequest
	{
        /// <summary>
        ///  党id,null表示自己所在的党
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}