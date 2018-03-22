using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取雪地营救过的好友 协议:221
    /// </summary>
	[Proto(value=221,description="获取雪地营救过的好友")]
	[ProtoContract]
	public class GetRescueFriendsRequest
	{
        /// <summary>
        ///  没啥用
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}