using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// ping协议的返回 协议:-7
    /// </summary>
	[Proto(value=-7,description="ping协议的返回")]
	[ProtoContract]
	public class Pong
	{
        /// <summary>
        ///  服务器的时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long time;
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