using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）驻军 协议:805
    /// </summary>
	[Proto(value=805,description="（公会战）驻军")]
	[ProtoContract]
	public class GVGGarrisonRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}