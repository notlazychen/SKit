using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看军团成员列表 协议:824
    /// </summary>
	[Proto(value=824,description="查看军团成员列表")]
	[ProtoContract]
	public class GVGGuildMembersRequest
	{
        /// <summary>
        ///  本军团id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;

	}
}