using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开始雪地营救 协议:222
    /// </summary>
	[Proto(value=222,description="开始雪地营救")]
	[ProtoContract]
	public class StartRescueRequest
	{
        /// <summary>
        ///  好友id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string friendId;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int difficulty;

	}
}