using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看阵容信息 协议:150
    /// </summary>
	[Proto(value=150,description="查看阵容信息")]
	[ProtoContract]
	public class GetTeamInfoRequest
	{
        /// <summary>
        ///  想要查看的玩家Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}