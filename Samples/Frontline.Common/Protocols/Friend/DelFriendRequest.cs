using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 删除好友 协议:307
    /// </summary>
	[Proto(value=307,description="删除好友")]
	[ProtoContract]
	public class DelFriendRequest
	{
        /// <summary>
        ///  好友id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}