using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵工厂详细 协议:16
    /// </summary>
	[Proto(value=16,description="兵工厂详细")]
	[ProtoContract]
	public class FactoryRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}