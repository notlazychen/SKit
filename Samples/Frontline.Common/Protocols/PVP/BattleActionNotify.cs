using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）战斗行为 协议:-126
    /// </summary>
	[Proto(value=-126,description="（战斗服）战斗行为")]
	[ProtoContract]
	public class BattleActionNotify
	{
        /// <summary>
        ///  行为
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public ArmyOperate armyOperate;
        /// <summary>
        ///  执行者pid
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public string pid;
        /// <summary>
        ///  行为执行时间戳
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public long time;

	}
}