using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ResPointInfo
	{
        /// <summary>
        ///  位置id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pointId;
        /// <summary>
        ///  对应的野怪id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int monsterId;
        /// <summary>
        ///  剩余血量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int hp;
        /// <summary>
        ///  剩余资源量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int resCnt;
        /// <summary>
        ///  剩余资源类型
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int resType;
        /// <summary>
        ///  可能掉落的道具
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<int> itemIds;
        /// <summary>
        ///  是否交战中
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public bool battling;

	}
}