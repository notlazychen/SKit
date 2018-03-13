using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取七日福利 协议:714
    /// </summary>
	[Proto(value=714,description="领取七日福利")]
	[ProtoContract]
	public class ReceiveWalfareRequest
	{
        /// <summary>
        ///  活动类型(1:登录 2:任务 3:钻石抢购 4:一元礼包)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  活动Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int id;

	}
}