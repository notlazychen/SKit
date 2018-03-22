using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 移除战斗服务器 协议:5002
    /// </summary>
	[Proto(value=5002,description="移除战斗服务器")]
	[ProtoContract]
	public class S2SRemoveBattleServer
	{
        /// <summary>
        ///  address
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string address;

	}
}