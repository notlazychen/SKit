using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GVGBattleInfo
	{
        /// <summary>
        ///  战斗记录id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string battleId;
        /// <summary>
        ///  进攻方名字
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string attackerName;
        /// <summary>
        ///  进攻所属军团id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string attackerGid;
        /// <summary>
        ///  防守方id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string defenderId;
        /// <summary>
        ///  战斗时间
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public long time;
        /// <summary>
        ///  是否胜利
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool win;

	}
}