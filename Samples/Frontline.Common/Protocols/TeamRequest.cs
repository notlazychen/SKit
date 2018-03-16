using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看阵容 协议:24
    /// </summary>
	[Proto(value=24,description="查看阵容")]
	[ProtoContract]
	public class TeamRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}