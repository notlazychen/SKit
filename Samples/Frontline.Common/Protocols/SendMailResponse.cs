using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 发送邮件返回 协议:-55
    /// </summary>
	[Proto(value=-55,description="发送邮件返回")]
	[ProtoContract]
	public class SendMailResponse
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