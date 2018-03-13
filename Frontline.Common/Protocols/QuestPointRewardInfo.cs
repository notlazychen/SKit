using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class QuestPointRewardInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  需要点数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int point;
        /// <summary>
        ///  itemId
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  是否已领取
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool recved;

	}
}