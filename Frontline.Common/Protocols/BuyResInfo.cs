using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class BuyResInfo
	{
        /// <summary>
        ///  购买的资源类型
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  购买次数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int times;
        /// <summary>
        ///  剩余购买次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int timesRemain;
        /// <summary>
        ///  下次购买花费(钻石)
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int cost;
        /// <summary>
        ///  下次购买的数量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int count;

	}
}