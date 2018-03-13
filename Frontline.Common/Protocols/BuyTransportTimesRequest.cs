using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买运输副本挑战次数 协议:623
    /// </summary>
	[Proto(value=623,description="购买运输副本挑战次数")]
	[ProtoContract]
	public class BuyTransportTimesRequest
	{
        /// <summary>
        ///  nothing
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string nothing;

	}
}