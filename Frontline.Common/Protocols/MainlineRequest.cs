using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求当前主线 协议:330
    /// </summary>
	[Proto(value=330,description="请求当前主线")]
	[ProtoContract]
	public class MainlineRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}