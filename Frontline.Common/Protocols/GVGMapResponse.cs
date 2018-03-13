using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战内）公会战战场信息 协议:-800
    /// </summary>
	[Proto(value=-800,description="（公会战内）公会战战场信息")]
	[ProtoContract]
	public class GVGMapResponse
	{
        /// <summary>
        ///  公会情报
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<CityPointInfo> cities;
        /// <summary>
        ///  资源点信息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<ResPointInfo> resPoint;
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