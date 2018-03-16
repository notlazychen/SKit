using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 群发邮件 协议:366
    /// </summary>
	[Proto(value=366,description="群发邮件")]
	[ProtoContract]
	public class MassMailRequest
	{
        /// <summary>
        ///  军团id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
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