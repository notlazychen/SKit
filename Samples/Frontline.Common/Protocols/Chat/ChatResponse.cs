using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 聊天返回 协议:-60
    /// </summary>
	[Proto(value=-60,description="聊天返回")]
	[ProtoContract]
	public class ChatResponse
	{
        /// <summary>
        ///  聊天类型(0世界1阵营2军团3私聊)
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  聊天内容(文字)
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string text;
        /// <summary>
        ///  发送者id
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string from;
        /// <summary>
        ///  发送者icon
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  发送者昵称
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string nickyName;
        /// <summary>
        ///  发送者等级
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int level;
        /// <summary>
        ///  发送者所在军团名称
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string partyName;
        /// <summary>
        ///  发送者所在阵营
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int camp;
        /// <summary>
        ///  发送者vip等级
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public long time;
        /// <summary>
        ///  语音信息
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public byte[] voice;
        /// <summary>
        ///  私聊的话标识对方是否在线
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public bool targetOnline;
        /// <summary>
        ///  是否系统发送
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public bool isSystem;
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