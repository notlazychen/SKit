using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党详情 协议:-359
    /// </summary>
	[Proto(value=-359,description="党详情")]
	[ProtoContract]
	public class PartyDetailResponse
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  党简介
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public PartyInfo pi;
        /// <summary>
        ///  党员名单
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
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