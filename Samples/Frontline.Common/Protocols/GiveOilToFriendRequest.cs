using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 赠送好友原油 协议:302
    /// </summary>
	[Proto(value=302,description="赠送好友原油")]
	[ProtoContract]
	public class GiveOilToFriendRequest
	{
        /// <summary>
        ///  好友id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否一键赠送
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool all;

	}
}