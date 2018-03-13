using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）战斗开始 协议:-128
    /// </summary>
	[Proto(value=-128,description="（战斗服）战斗开始")]
	[ProtoContract]
	public class BattleStartNotify
	{
        /// <summary>
        ///  战斗开始时间
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public long startTime;

	}
}