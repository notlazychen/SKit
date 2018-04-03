using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党费 协议:357
    /// </summary>
	[Proto(value=357,description="党费")]
	[ProtoContract]
	public class PartyContriRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}