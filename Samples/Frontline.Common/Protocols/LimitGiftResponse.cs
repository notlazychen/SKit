using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 限时充值活动礼包列表 协议:-705
    /// </summary>
	[Proto(value=-705,description="限时充值活动礼包列表")]
	[ProtoContract]
	public class LimitGiftResponse
	{
        /// <summary>
        ///  礼包列表
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<LimitGiftInfo> giftInfos;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}