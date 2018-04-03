using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党员列表 协议:-353
    /// </summary>
	[Proto(value=-353,description="党员列表")]
	[ProtoContract]
	public class MemberListResponse
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  党员
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<PartyMemberInfo> members;
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