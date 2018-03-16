using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 发起匹配 协议:120
    /// </summary>
	[Proto(value=120,description="发起匹配")]
	[ProtoContract]
	public class MatchRequest
	{
        /// <summary>
        ///  匹配玩法，0普通匹配，1天梯匹配,2抢滩保卫
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int type;
        /// <summary>
        ///  难度 1普通，2精英，3专家
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int difficult;

	}
}