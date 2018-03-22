using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买成长套餐返回 协议:-703
    /// </summary>
	[Proto(value=-703,description="购买成长套餐返回")]
	[ProtoContract]
	public class ActivityBuyCZResponse
	{
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}