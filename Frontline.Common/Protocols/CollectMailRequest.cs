using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收藏邮件 协议:56
    /// </summary>
	[Proto(value=56,description="收藏邮件")]
	[ProtoContract]
	public class CollectMailRequest
	{
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}