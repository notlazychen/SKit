using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 删除好友推送 协议:-311
    /// </summary>
	[Proto(value=-311,description="删除好友推送")]
	[ProtoContract]
	public class FriendDelNotify
	{
        /// <summary>
        ///  要删除的好友id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
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