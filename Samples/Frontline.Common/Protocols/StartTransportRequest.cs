using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求开始运输玩法 协议:621
    /// </summary>
	[Proto(value=621,description="请求开始运输玩法")]
	[ProtoContract]
	public class StartTransportRequest
	{
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int difficultDegree;

	}
}