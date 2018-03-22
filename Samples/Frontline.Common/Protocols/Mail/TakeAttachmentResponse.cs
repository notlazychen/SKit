using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取附件 协议:-52
    /// </summary>
	[Proto(value=-52,description="领取附件")]
	[ProtoContract]
	public class TakeAttachmentResponse
	{
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<string> mails;
        /// <summary>
        ///  获得的东西
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo reward;
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