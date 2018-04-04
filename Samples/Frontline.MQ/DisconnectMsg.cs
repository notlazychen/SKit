using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 离开战场 协议:5006
    /// </summary>
	[Proto(value=9999,description="离开战场")]
	[ProtoContract]
    public class DisconnectMsg
	{
        /// <summary>
        ///  战斗结果
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string reason;
	}
}