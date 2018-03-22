using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买成长套餐 协议:703
    /// </summary>
	[Proto(value=703,description="购买成长套餐")]
	[ProtoContract]
	public class ActivityBuyCZRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tag;

	}
}