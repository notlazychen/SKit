using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 好友列表 协议:300
    /// </summary>
	[Proto(value=300,description="好友列表")]
	[ProtoContract]
	public class FriendListRequest
	{
        /// <summary>
        ///  玩家id，null表示自己
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}