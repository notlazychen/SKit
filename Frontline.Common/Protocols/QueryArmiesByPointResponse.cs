using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求该点关联的部队 协议:-813
    /// </summary>
	[Proto(value=-813,description="请求该点关联的部队")]
	[ProtoContract]
	public class QueryArmiesByPointResponse
	{
        /// <summary>
        ///  armies
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<ArmyInfo> armies;
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