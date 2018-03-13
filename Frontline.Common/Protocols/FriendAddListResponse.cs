using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 好友申请列表 协议:-305
    /// </summary>
	[Proto(value=-305,description="好友申请列表")]
	[ProtoContract]
	public class FriendAddListResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  申请列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<FriendInfo> ps;
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