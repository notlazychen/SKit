using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 好友申请列表 协议:305
    /// </summary>
	[Proto(value=305,description="好友申请列表")]
	[ProtoContract]
	public class FriendAddListRequest
	{
        /// <summary>
        ///  玩家id，null表示自己
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}