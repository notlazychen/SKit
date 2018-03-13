using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求周常信息 协议:910
    /// </summary>
	[Proto(value=910,description="请求周常信息")]
	[ProtoContract]
	public class GetWeekInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}