using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 取消收藏邮件 协议:-57
    /// </summary>
	[Proto(value=-57,description="取消收藏邮件")]
	[ProtoContract]
	public class CancelCollectResponse
	{
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string mid;
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