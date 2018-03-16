using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// cz 协议:-5
    /// </summary>
	[Proto(value=-5,description="cz")]
	[ProtoContract]
	public class RechargeResponse
	{
		[ProtoMember(3, IsRequired = false)]
		public int cnt;
		[ProtoMember(4, IsRequired = false)]
		public int id;
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