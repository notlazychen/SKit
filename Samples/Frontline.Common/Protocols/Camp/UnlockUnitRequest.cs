using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求解锁兵种 协议:132
    /// </summary>
	[Proto(value=132,description="请求解锁兵种")]
	[ProtoContract]
	public class UnlockUnitRequest
	{
        /// <summary>
        ///  解锁兵种id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int unitId;

	}
}