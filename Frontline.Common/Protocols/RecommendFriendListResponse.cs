using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 推荐好友列表 协议:-303
    /// </summary>
	[Proto(value=-303,description="推荐好友列表")]
	[ProtoContract]
	public class RecommendFriendListResponse
	{
        /// <summary>
        ///  玩家id，null表示自己
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  推荐好友列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<FriendInfo> friends;
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