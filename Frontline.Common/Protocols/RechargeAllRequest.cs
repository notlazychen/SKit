using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求所有充值活动信息 协议:1202
    /// </summary>
	[Proto(value=1202,description="请求所有充值活动信息")]
	[ProtoContract]
	public class RechargeAllRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}