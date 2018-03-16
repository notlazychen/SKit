using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVPFlag
	{
        /// <summary>
        ///  旗帜Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int flagId;
        /// <summary>
        ///  所属方
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int group;
        /// <summary>
        ///  当前进度
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int progress;

	}
}