using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GuildMessageInfo
	{
        /// <summary>
        ///  私信Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  发送公会Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string sendGid;
        /// <summary>
        ///  发送公会会长名字
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string senderName;
        /// <summary>
        ///  发送公会会长Icon
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string senderIcon;
        /// <summary>
        ///  发送时间
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public long sendTime;
        /// <summary>
        ///  消息
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string msg;

	}
}