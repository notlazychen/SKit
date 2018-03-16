using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）出战 协议:804
    /// </summary>
	[Proto(value=804,description="（公会战）出战")]
	[ProtoContract]
	public class GVGFightRequest
	{
        /// <summary>
        ///  目的地
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string destPositionId;
        /// <summary>
        ///  是否加速
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool speedUp;

	}
}