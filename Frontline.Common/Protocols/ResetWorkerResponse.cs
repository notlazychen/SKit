using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 重置工人 协议:-117
    /// </summary>
	[Proto(value=-117,description="重置工人")]
	[ProtoContract]
	public class ResetWorkerResponse
	{
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int diamond;
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