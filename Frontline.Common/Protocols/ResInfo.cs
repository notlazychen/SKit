using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ResInfo
	{
        /// <summary>
        ///  资源Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  资源数量
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int count;

	}
}