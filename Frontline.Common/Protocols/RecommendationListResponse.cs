using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求推荐列表 协议:-1311
    /// </summary>
	[Proto(value=-1311,description="请求推荐列表")]
	[ProtoContract]
	public class RecommendationListResponse
	{
        /// <summary>
        ///  0推荐1军团2好友
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  玩家
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<MemberInfo> members;
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