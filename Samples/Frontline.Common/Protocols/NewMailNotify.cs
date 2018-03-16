using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 新邮件通知 协议:-99
    /// </summary>
	[Proto(value=-99,description="新邮件通知")]
	[ProtoContract]
	public class NewMailNotify
	{
        /// <summary>
        ///  新邮件
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public MailInfo mail;
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