using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）抢滩保卫战，出兵 协议:-657
    /// </summary>
	[Proto(value=-657,description="（战斗服）抢滩保卫战，出兵")]
	[ProtoContract]
	public class MultiDefenceEnemyCreatedNotify
	{
        /// <summary>
        ///  怪物
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public MonsterInfo monsters;
        /// <summary>
        ///  第几波
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int wave;
        /// <summary>
        ///  第几只
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int number;

	}
}