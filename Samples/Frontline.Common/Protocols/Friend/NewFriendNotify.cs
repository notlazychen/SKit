using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 新好友通知 协议:-308
    /// </summary>
	[Proto(value=-308,description="新好友通知")]
	[ProtoContract]
	public class NewFriendNotify
	{
        /// <summary>
        ///  新好友
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public FriendInfo friend;
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