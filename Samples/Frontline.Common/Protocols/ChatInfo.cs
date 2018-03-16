using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ChatInfo
	{
        /// <summary>
        ///  聊天类型(0世界1阵营2军团3私聊)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  聊天内容(文字)
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string text;
        /// <summary>
        ///  发送者id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string from;
        /// <summary>
        ///  发送者icon
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  发送者昵称
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string nickyName;
        /// <summary>
        ///  发送者等级
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int level;
        /// <summary>
        ///  发送者所在军团名称
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string partyName;
        /// <summary>
        ///  发送者所在阵营
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int camp;
        /// <summary>
        ///  发送者vip等级
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public long time;
        /// <summary>
        ///  是否系统发送
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public bool isSystem;

	}
}