using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 交党费 协议:358
    /// </summary>
	[Proto(value=358,description="交党费")]
	[ProtoContract]
	public class PayPartyRequest
	{
        /// <summary>
        ///  党费id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int contri;

	}
}