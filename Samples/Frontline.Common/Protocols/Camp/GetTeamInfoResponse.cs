using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看阵容信息 协议:-150
    /// </summary>
	[Proto(value=-150,description="查看阵容信息")]
	[ProtoContract]
	public class GetTeamInfoResponse
	{
        /// <summary>
        ///  想要查看的玩家Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  阵容
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<TeamPlaceInfo> team;
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