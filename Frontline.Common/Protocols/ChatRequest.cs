using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 聊天请求 协议:60
    /// </summary>
	[Proto(value=60,description="聊天请求")]
	[ProtoContract]
	public class ChatRequest
	{
        /// <summary>
        ///  聊天类型(0世界1阵营2军团3私聊)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  发送的玩家id（私聊需要传递）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string to;
        /// <summary>
        ///  聊天内容(文字)
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string text;
        /// <summary>
        ///  语音信息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public byte[] voice;

	}
}