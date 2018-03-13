using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 显示战斗服务器返回 协议:5004
    /// </summary>
	[Proto(value=5004,description="显示战斗服务器返回")]
	[ProtoContract]
	public class S2SShowBattleServersResponse
	{
        /// <summary>
        ///  服务器
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<S2SBattleServerInfo> servers;

	}
}