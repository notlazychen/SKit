using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看军团成员列表 协议:-824
    /// </summary>
	[Proto(value=-824,description="查看军团成员列表")]
	[ProtoContract]
	public class GVGGuildMembersResponse
	{
        /// <summary>
        ///  成员列表
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<GuildMemberInfo> members;
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