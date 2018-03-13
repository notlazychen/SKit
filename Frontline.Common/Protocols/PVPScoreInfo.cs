using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVPScoreInfo
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  group
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int group;
        /// <summary>
        ///  分数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int score;
        /// <summary>
        ///  旗帜数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int flagCount;
        /// <summary>
        ///  造兵点数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int createUnitPoint;

	}
}