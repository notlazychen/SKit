using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）设置出征阵容 协议:-811
    /// </summary>
	[Proto(value=-811,description="（公会战）设置出征阵容")]
	[ProtoContract]
	public class GVGSetTeamResponse
	{
        /// <summary>
        ///  兵种
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string uid;
        /// <summary>
        ///  是否上阵
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool selected;
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