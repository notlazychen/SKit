using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求充值信息 协议:710
    /// </summary>
	[Proto(value=710,description="请求充值信息")]
	[ProtoContract]
	public class RechargeInfoRequest
	{
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}