using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 战斗结束 协议:-129
    /// </summary>
	[Proto(value=-129,description="战斗结束")]
	[ProtoContract]
	public class BattleEndNotify
	{
        /// <summary>
        ///  结果
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public MatchBattleResultInfo resultInfo;

	}
}