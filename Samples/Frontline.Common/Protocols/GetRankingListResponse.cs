using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 排行榜 协议:-151
    /// </summary>
	[Proto(value=-151,description="排行榜")]
	[ProtoContract]
	public class GetRankingListResponse
	{
        /// <summary>
        ///  排行榜类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  我在榜中的排名
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int myRank;
        /// <summary>
        ///  排行榜前五十
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<RankInfo> rankInfos;
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