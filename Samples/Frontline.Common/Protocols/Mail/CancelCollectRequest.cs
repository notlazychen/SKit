using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 取消收藏邮件 协议:57
    /// </summary>
	[Proto(value=57,description="取消收藏邮件")]
	[ProtoContract]
	public class CancelCollectRequest
	{
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}