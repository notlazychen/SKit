using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 作弊返回 协议:-200
    /// </summary>
	[Proto(value=-200,description="作弊返回")]
	[ProtoContract]
	public class CheatResponse
	{
        /// <summary>
        ///  类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
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