using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 邮件列表 协议:50
    /// </summary>
	[Proto(value=50,description="邮件列表")]
	[ProtoContract]
	public class MailListRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  页数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int page;

	}
}