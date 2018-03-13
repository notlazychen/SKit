using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class S2SLadderInfo
	{
        /// <summary>
        ///  军衔
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int ladderMrk;
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int ladderScore;
        /// <summary>
        ///  积分旧
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int ladderScoreOld;
        /// <summary>
        ///  军衔旧
        /// </summary>
		[ProtoMember(4, IsRequired = true)]
		public int ladderMrkOld;

	}
}