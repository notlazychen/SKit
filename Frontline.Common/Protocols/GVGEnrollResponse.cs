using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 公会战报名结果返回 协议:-803
    /// </summary>
	[Proto(value=-803,description="公会战报名结果返回")]
	[ProtoContract]
	public class GVGEnrollResponse
	{
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