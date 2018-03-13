using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）加速行军 协议:807
    /// </summary>
	[Proto(value=807,description="（公会战）加速行军")]
	[ProtoContract]
	public class GVGSpeedUpRequest
	{
        /// <summary>
        ///  部队id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}