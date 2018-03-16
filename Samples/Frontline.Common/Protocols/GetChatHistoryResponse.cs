using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取聊天记录 协议:-61
    /// </summary>
	[Proto(value=-61,description="获取聊天记录")]
	[ProtoContract]
	public class GetChatHistoryResponse
	{
        /// <summary>
        ///  聊天纪录
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<ChatHistory> histories;
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