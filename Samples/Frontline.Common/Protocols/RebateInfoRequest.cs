using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求充值信息 协议:901
    /// </summary>
	[Proto(value=901,description="请求充值信息")]
	[ProtoContract]
	public class RebateInfoRequest
	{
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}