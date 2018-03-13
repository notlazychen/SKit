using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 阅读邮件 协议:51
    /// </summary>
	[Proto(value=51,description="阅读邮件")]
	[ProtoContract]
	public class ReadMailRequest
	{
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}