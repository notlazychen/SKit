using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）查询战斗状态，战斗是否开启 协议:511
    /// </summary>
	[Proto(value=511,description="（战斗服）查询战斗状态，战斗是否开启")]
	[ProtoContract]
	public class BattleStateRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}