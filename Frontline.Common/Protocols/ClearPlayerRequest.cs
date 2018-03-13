using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 清档 协议:1001
    /// </summary>
	[Proto(value=1001,description="清档")]
	[ProtoContract]
	public class ClearPlayerRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string pid;

	}
}