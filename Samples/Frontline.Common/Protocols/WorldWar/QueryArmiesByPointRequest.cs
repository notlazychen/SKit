using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求该点关联的部队 协议:813
    /// </summary>
	[Proto(value=813,description="请求该点关联的部队")]
	[ProtoContract]
	public class QueryArmiesByPointRequest
	{
        /// <summary>
        ///  pointId
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pointId;

	}
}