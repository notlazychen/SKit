using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// VIP信息改变的推送 协议:-402
    /// </summary>
	[Proto(value=-402,description="VIP信息改变的推送")]
	[ProtoContract]
	public class VIPInfoChangedNotify
	{
        /// <summary>
        ///  新的VIP等级
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int vip;
        /// <summary>
        /// 到期时间
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
        public long endTime;
    }
}