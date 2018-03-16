using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 激活兵种 协议:654
    /// </summary>
	[Proto(value=654,description="激活兵种")]
	[ProtoContract]
	public class MultiDefenceActivateUnitRequest
	{
        /// <summary>
        ///  要激活的兵种Id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int unitId;

	}
}