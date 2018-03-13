using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 返回删除邮件 协议:-54
    /// </summary>
	[Proto(value=-54,description="返回删除邮件")]
	[ProtoContract]
	public class DeleteMailResponse
	{
        /// <summary>
        ///  邮件id列表
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<string> mids;
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