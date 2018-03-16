using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GrabFlagScoreInfo
	{
        /// <summary>
        ///  奖励Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  领取需要的积分
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int score;
        /// <summary>
        ///  是否已经领取
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool received;

	}
}