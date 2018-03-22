using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 好友列表 协议:-300
    /// </summary>
	[Proto(value=-300,description="好友列表")]
	[ProtoContract]
	public class FriendListResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  最大可领取原油次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int maxOilTimes;
        /// <summary>
        ///  已领取原油次数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int oilTimes;
        /// <summary>
        ///  好友列表
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
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