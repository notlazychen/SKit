using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 邮件列表 协议:-50
    /// </summary>
	[Proto(value=-50,description="邮件列表")]
	[ProtoContract]
	public class MailListResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  邮件列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<MailInfo> mails;
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