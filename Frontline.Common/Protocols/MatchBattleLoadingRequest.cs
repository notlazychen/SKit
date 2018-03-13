using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）读条 协议:125
    /// </summary>
	[Proto(value=125,description="（战斗服）读条")]
	[ProtoContract]
	public class MatchBattleLoadingRequest
	{
        /// <summary>
        ///  我的进度
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int progress;

	}
}