using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class DropItem
	{
        /// <summary>
        ///  道具id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  道具数量
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int cnt;

	}
}