using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVEPatternInfo
	{
        /// <summary>
        ///  玩法类型 0雪地营救
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  剩余次数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int remainTimes;
        /// <summary>
        ///  总次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int totalTimes;

	}
}