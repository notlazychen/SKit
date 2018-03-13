using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 分配工人 协议:108
    /// </summary>
	[Proto(value=108,description="分配工人")]
	[ProtoContract]
	public class AllotWorkerRequest
	{
        /// <summary>
        ///  工厂type
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  工人数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int workerCnt;

	}
}