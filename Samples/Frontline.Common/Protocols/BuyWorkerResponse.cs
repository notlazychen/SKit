using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买工人返回 协议:-107
    /// </summary>
	[Proto(value=-107,description="购买工人返回")]
	[ProtoContract]
	public class BuyWorkerResponse
	{
        /// <summary>
        ///  拥有工人数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int totalWorkers;
        /// <summary>
        ///  空闲工人数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int idleWorkers;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
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