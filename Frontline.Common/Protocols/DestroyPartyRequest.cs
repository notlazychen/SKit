using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 解散 协议:364
    /// </summary>
	[Proto(value=364,description="解散")]
	[ProtoContract]
	public class DestroyPartyRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}