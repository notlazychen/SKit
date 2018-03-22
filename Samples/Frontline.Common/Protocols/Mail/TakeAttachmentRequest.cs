using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领附件 协议:52
    /// </summary>
	[Proto(value=52,description="领附件")]
	[ProtoContract]
	public class TakeAttachmentRequest
	{
        /// <summary>
        ///  是否全部提取，若全部提取则无视邮件Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool allTake;
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string id;

	}
}