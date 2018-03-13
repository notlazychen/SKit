using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取玩家的运输玩法数据 协议:620
    /// </summary>
	[Proto(value=620,description="获取玩家的运输玩法数据")]
	[ProtoContract]
	public class GetTransportInfoRequest
	{
        /// <summary>
        ///  无用字段
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}