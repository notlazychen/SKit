using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）战斗主机 协议:-127
    /// </summary>
	[Proto(value=-127,description="（战斗服）战斗主机")]
	[ProtoContract]
	public class BattleHostNotify
	{
        /// <summary>
        ///  主机的Pid
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string pid;

	}
}