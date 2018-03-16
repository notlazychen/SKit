using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求排行榜 协议:151
    /// </summary>
	[Proto(value=151,description="请求排行榜")]
	[ProtoContract]
	public class GetRankingListRequest
	{
        /// <summary>
        ///  排行榜类型
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;

	}
}