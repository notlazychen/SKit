using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 一键添加好友 协议:312
    /// </summary>
	[Proto(value=312,description="一键添加好友")]
	[ProtoContract]
	public class ProcessAllFriendAddRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}