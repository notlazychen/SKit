using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ResourceInfo
	{
        /// <summary>
        ///  1资源2道具
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  道具id/资源类型
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int id;
        /// <summary>
        ///  道具/资源数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int count;

	}
}