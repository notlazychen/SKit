using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收取好友赠送的原油 协议:301
    /// </summary>
	[Proto(value=301,description="收取好友赠送的原油")]
	[ProtoContract]
	public class GetOilFromFriendRequest
	{
        /// <summary>
        ///  好友id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否一键收取
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool all;

	}
}