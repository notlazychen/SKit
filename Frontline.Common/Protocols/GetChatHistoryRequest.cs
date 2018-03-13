using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取聊天记录 协议:61
    /// </summary>
	[Proto(value=61,description="获取聊天记录")]
	[ProtoContract]
	public class GetChatHistoryRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}