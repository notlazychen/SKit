using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ChatHistory
	{
        /// <summary>
        ///  聊天信息
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<ChatInfo> chats;
        /// <summary>
        ///  聊天类型(0世界1阵营2军团3私聊)
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;

	}
}