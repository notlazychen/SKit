using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 显示战斗服务器 协议:5003
    /// </summary>
	[Proto(value=5003,description="显示战斗服务器")]
	[ProtoContract]
	public class S2SShowBattleServersRequest
	{
        /// <summary>
        ///  nothing
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int nothing;

	}
}