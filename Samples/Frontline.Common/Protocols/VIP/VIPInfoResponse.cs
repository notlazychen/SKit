using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// VIP信息返回 协议:-400
    /// </summary>
	[Proto(value=-400,description="VIP信息返回")]
	[ProtoContract]
	public class VIPInfoResponse
	{
        /// <summary>
        ///  当前VIP等级
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  到期时间
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
        public long endTime;
        /// <summary>
        ///  今日是否领取过金币钻石
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
        public bool recved;
    }
}