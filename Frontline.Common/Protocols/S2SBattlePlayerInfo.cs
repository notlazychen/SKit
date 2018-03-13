using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class S2SBattlePlayerInfo
	{
        /// <summary>
        ///  info
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public MatchBattlePlayerInfo info;
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public string token;

	}
}