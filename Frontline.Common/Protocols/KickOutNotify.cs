using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 踢下线，不要重连 协议:-140
    /// </summary>
	[Proto(value=-140,description="踢下线，不要重连")]
	[ProtoContract]
	public class KickOutNotify
	{
        /// <summary>
        ///  0被顶号，1检测出作弊
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int reason;
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