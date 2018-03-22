using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 添加好友 协议:304
    /// </summary>
	[Proto(value=304,description="添加好友")]
	[ProtoContract]
	public class AddFriendRequest
	{
        /// <summary>
        ///  待加为好友的玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}