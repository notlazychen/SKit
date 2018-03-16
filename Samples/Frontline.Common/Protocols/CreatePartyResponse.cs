using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 建党 协议:-350
    /// </summary>
	[Proto(value=-350,description="建党")]
	[ProtoContract]
	public class CreatePartyResponse
	{
        /// <summary>
        ///  党
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public PartyInfo party;
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