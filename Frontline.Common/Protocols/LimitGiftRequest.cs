using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求限时活动礼包 协议:705
    /// </summary>
	[Proto(value=705,description="请求限时活动礼包")]
	[ProtoContract]
	public class LimitGiftRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}