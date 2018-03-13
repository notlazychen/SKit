using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 阵容 协议:-24
    /// </summary>
	[Proto(value=-24,description="阵容")]
	[ProtoContract]
	public class TeamResponse
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  五位的阵容集合
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<TeamInfo> teams5;
        /// <summary>
        ///  十位的阵容集合
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<TeamInfo> teams10;
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