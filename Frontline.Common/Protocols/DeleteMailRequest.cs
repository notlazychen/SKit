using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 删除邮件请求 协议:54
    /// </summary>
	[Proto(value=54,description="删除邮件请求")]
	[ProtoContract]
	public class DeleteMailRequest
	{
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<string> mids;

	}
}