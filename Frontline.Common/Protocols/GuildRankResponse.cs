using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看军团排行榜 协议:-829
    /// </summary>
	[Proto(value=-829,description="查看军团排行榜")]
	[ProtoContract]
	public class GuildRankResponse
	{
        /// <summary>
        ///  排行榜
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<GuildRankInfo> rankinglist;
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