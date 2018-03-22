using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开启战场返回 协议:5007
    /// </summary>
	[Proto(value=5007,description="开启战场返回")]
	[ProtoContract]
	public class S2SEnterBattleOkResponse
	{
        /// <summary>
        ///  pids
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<string> pids;
        /// <summary>
        ///  ip
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public string ip;
        /// <summary>
        ///  port
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int port;

	}
}