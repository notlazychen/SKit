using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）设置出征阵容 协议:811
    /// </summary>
	[Proto(value=811,description="（公会战）设置出征阵容")]
	[ProtoContract]
	public class GVGSetTeamRequest
	{
        /// <summary>
        ///  兵种ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string uid;

	}
}