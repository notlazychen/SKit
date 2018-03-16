using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）抢滩保卫战，积分改变 协议:-655
    /// </summary>
	[Proto(value=-655,description="（战斗服）抢滩保卫战，积分改变")]
	[ProtoContract]
	public class MultiDefenceScoreChangeNotify
	{
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int score;
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public string pid;

	}
}