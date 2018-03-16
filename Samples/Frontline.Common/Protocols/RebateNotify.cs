using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买返利推送 协议:-909
    /// </summary>
	[Proto(value=-909,description="购买返利推送")]
	[ProtoContract]
	public class RebateNotify
	{
        /// <summary>
        ///  返利id推送
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  剩余购买次数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int cnt;

	}
}