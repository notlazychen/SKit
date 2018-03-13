using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RewardInfo
	{
        /// <summary>
        ///  经验
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  资源集合
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<ResInfo> res;
        /// <summary>
        ///  物品集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<RewardItem> items;
        /// <summary>
        ///  解锁兵种
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<UnitInfo> units;

	}
}