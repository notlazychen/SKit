using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）抢滩保卫战，下一波开始 协议:-650
    /// </summary>
	[Proto(value=-650,description="（战斗服）抢滩保卫战，下一波开始")]
	[ProtoContract]
	public class MultiDefenceEnemyWaveNotify
	{
        /// <summary>
        ///  波次
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int wave;

	}
}