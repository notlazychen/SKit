using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取玩法信息 协议:220
    /// </summary>
	[Proto(value=220,description="获取玩法信息")]
	[ProtoContract]
	public class GetPatternInfoRequest
	{
        /// <summary>
        ///  没啥用
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}