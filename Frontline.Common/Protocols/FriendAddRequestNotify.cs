using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收到加好友申请 协议:-309
    /// </summary>
	[Proto(value=-309,description="收到加好友申请")]
	[ProtoContract]
	public class FriendAddRequestNotify
	{
        /// <summary>
        ///  申请者详情
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