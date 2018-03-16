using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求夺旗战的对手列表 协议:142
    /// </summary>
	[Proto(value=142,description="请求夺旗战的对手列表")]
	[ProtoContract]
	public class GrabFlagAdversariesRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}