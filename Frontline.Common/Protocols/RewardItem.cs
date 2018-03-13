using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RewardItem
	{
        /// <summary>
        ///  物品id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string name;
        /// <summary>
        ///  道具类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  道具品质
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int quality;
        /// <summary>
        ///  Icon_Id
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int icon;
        /// <summary>
        ///  数量
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int count;

	}
}