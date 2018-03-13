using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求大厅信息 协议:1301
    /// </summary>
	[Proto(value=1301,description="请求大厅信息")]
	[ProtoContract]
	public class HallInfoRequest
	{
        /// <summary>
        ///  玩法类型0全部 1天梯，2抢滩，3单人匹配
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int diff;

	}
}