using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求获取vip信息 协议:400
    /// </summary>
	[Proto(value=400,description="请求获取vip信息")]
	[ProtoContract]
	public class VIPInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}