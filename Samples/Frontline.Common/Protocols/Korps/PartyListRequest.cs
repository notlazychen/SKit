using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党列表 协议:352
    /// </summary>
	[Proto(value=352,description="党列表")]
	[ProtoContract]
	public class PartyListRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}