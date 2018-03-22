using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 阅读邮件 协议:-51
    /// </summary>
	[Proto(value=-51,description="阅读邮件")]
	[ProtoContract]
	public class ReadMailResponse
	{
        /// <summary>
        ///  邮件id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否已经阅读过
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool readed;
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