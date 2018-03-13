using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求后勤基地信息 协议:103
    /// </summary>
	[Proto(value=103,description="请求后勤基地信息")]
	[ProtoContract]
	public class GetIndustryInfoRequest
	{
        /// <summary>
        ///  没用
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}