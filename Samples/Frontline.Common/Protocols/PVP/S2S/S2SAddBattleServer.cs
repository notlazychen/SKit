using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 添加战斗服务器 协议:5001
    /// </summary>
	[Proto(value=5001,description="添加战斗服务器")]
	[ProtoContract]
	public class S2SAddBattleServer
	{
        /// <summary>
        ///  战斗服务器
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public S2SBattleServerInfo battleServerInfo;

	}
}