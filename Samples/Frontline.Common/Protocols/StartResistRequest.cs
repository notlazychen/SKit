using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开战 协议:71
    /// </summary>
	[Proto(value=71,description="开战")]
	[ProtoContract]
	public class StartResistRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}