using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看资源点详情 协议:820
    /// </summary>
	[Proto(value=820,description="查看资源点详情")]
	[ProtoContract]
	public class ResPointRequest
	{
        /// <summary>
        ///  pointId
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pointId;

	}
}