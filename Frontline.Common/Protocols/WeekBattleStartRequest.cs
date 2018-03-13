using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 挑战周常关卡 协议:911
    /// </summary>
	[Proto(value=911,description="挑战周常关卡")]
	[ProtoContract]
	public class WeekBattleStartRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int diff;

	}
}