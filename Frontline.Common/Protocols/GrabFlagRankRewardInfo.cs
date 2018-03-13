using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GrabFlagRankRewardInfo
	{
        /// <summary>
        ///  排名段
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<int> rank_area;
        /// <summary>
        ///  道具Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<int> items_id;
        /// <summary>
        ///  道具数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<int> items_cnt;

	}
}