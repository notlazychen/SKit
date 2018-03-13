using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 推荐好友列表 协议:303
    /// </summary>
	[Proto(value=303,description="推荐好友列表")]
	[ProtoContract]
	public class RecommendFriendListRequest
	{
        /// <summary>
        ///  玩家id，null表示自己
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}