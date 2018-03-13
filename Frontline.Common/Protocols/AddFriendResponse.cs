using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 添加好友 协议:-304
    /// </summary>
	[Proto(value=-304,description="添加好友")]
	[ProtoContract]
	public class AddFriendResponse
	{
        /// <summary>
        ///  待加为好友的玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
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