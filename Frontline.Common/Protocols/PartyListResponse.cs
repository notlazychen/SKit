using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党列表 协议:-352
    /// </summary>
	[Proto(value=-352,description="党列表")]
	[ProtoContract]
	public class PartyListResponse
	{
        /// <summary>
        ///  党
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<PartyInfo> parties;
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