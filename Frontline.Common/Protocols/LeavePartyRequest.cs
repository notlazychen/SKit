using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 退党 协议:360
    /// </summary>
	[Proto(value=360,description="退党")]
	[ProtoContract]
	public class LeavePartyRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}