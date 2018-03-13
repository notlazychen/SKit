using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 并总升阶 协议:37
    /// </summary>
	[Proto(value=37,description="并总升阶")]
	[ProtoContract]
	public class ClazupUnitRequest
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string id;

	}
}