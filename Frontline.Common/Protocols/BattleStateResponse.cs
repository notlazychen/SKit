using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）返回战斗信息：战斗是否已经开始 协议:-511
    /// </summary>
	[Proto(value=-511,description="（战斗服）返回战斗信息：战斗是否已经开始")]
	[ProtoContract]
	public class BattleStateResponse
	{
        /// <summary>
        ///  1读条中，2战斗中，3战斗结束
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int state;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}