using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 玩家的运输玩法数据 协议:-620
    /// </summary>
	[Proto(value=-620,description="玩家的运输玩法数据")]
	[ProtoContract]
	public class GetTransportInfoResponse
	{
        /// <summary>
        ///  剩余次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int remainTimes;
        /// <summary>
        ///  总次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int totalTimes;
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