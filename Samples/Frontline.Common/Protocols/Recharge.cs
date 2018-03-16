using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// cz 协议:5
    /// </summary>
	[Proto(value=5,description="cz")]
	[ProtoContract]
	public class Recharge
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  回执receipt
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string code;
        /// <summary>
        ///  支付方式，苹果:0
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int way;

	}
}