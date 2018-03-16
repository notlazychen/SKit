using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RemainItemInfo
	{
        /// <summary>
        ///  物品id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  数量
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int count;

	}
}