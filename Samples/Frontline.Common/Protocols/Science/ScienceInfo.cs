using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ScienceInfo
	{
        /// <summary>
        ///  是否已经研发
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool open;
        /// <summary>
        ///  科技ID
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tid;
        /// <summary>
        ///  level
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int level;
        /// <summary>
        ///  是否研发中
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool dev;
        /// <summary>
        ///  研发结束时间
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public long devEndTime;

	}
}