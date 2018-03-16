using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 发送邮件请求 协议:55
    /// </summary>
	[Proto(value=55,description="发送邮件请求")]
	[ProtoContract]
	public class SendMailRequest
	{
        /// <summary>
        ///  收件人的名字
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string recvName;
        /// <summary>
        ///  正文
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string content;
        /// <summary>
        ///  标题
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string title;

	}
}