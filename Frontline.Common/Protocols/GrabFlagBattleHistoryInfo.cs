using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GrabFlagBattleHistoryInfo
	{
        /// <summary>
        ///  对手pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string adversaryPid;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  对手战力
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int power;
        /// <summary>
        ///  战斗结果-1败，1胜，0平
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int battleResult;
        /// <summary>
        ///  对手名字
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string adversaryName;
        /// <summary>
        ///  战斗时间
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public long battleTime;
        /// <summary>
        ///  排名变化，正数上升，负数下降，0不变
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int rankChange;

	}
}