using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求推荐列表 协议:1311
    /// </summary>
	[Proto(value=1311,description="请求推荐列表")]
	[ProtoContract]
	public class RecommendationListRequest
	{
        /// <summary>
        ///  0推荐1军团2好友
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;

	}
}