using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 回收兵种 协议:251
    /// </summary>
	[Proto(value=251,description="回收兵种")]
	[ProtoContract]
	public class ReclaimUnitRequest
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string id;
        /// <summary>
        ///  确定回收
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool sure;

	}
}