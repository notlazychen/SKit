using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取抽奖相关信息 协议:905
    /// </summary>
	[Proto(value=905,description="获取抽奖相关信息")]
	[ProtoContract]
	public class GetLotteryInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}