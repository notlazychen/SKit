using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class S2SBattleServerInfo
	{
        /// <summary>
        ///  address
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string address;
        /// <summary>
        ///  ip;
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