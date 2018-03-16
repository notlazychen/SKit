using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看玩家信息 协议:152
    /// </summary>
	[Proto(value=152,description="查看玩家信息")]
	[ProtoContract]
	public class ShowPlayerRequest
	{
        /// <summary>
        ///  要查看的玩家Id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string pid;

	}
}