using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看军团排行榜 协议:829
    /// </summary>
	[Proto(value=829,description="查看军团排行榜")]
	[ProtoContract]
	public class GuildRankRequest
	{
        /// <summary>
        ///  nothing
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string nothing;

	}
}