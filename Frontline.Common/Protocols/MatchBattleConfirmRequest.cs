using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 战斗开始确定 协议:123
    /// </summary>
	[Proto(value=123,description="战斗开始确定")]
	[ProtoContract]
	public class MatchBattleConfirmRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string pid;

	}
}