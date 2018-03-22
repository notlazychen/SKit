using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收藏邮件 协议:-56
    /// </summary>
	[Proto(value=-56,description="收藏邮件")]
	[ProtoContract]
	public class CollectMailResponse
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