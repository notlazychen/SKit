using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 取消匹配 协议:121
    /// </summary>
	[Proto(value=121,description="取消匹配")]
	[ProtoContract]
	public class MatchCancelRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string pid;

	}
}