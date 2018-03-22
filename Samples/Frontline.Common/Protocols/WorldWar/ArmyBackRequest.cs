using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 军队召回 协议:828
    /// </summary>
	[Proto(value=828,description="军队召回")]
	[ProtoContract]
	public class ArmyBackRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}