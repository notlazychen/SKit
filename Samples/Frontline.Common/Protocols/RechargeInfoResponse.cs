using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 充值信息返回 协议:-710
    /// </summary>
	[Proto(value=-710,description="充值信息返回")]
	[ProtoContract]
	public class RechargeInfoResponse
	{
        /// <summary>
        ///  充值记录
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<RechargeInfo> rechargeInfos;
        /// <summary>
        ///  累计充值金额
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public float rechargeDiamond;
        /// <summary>
        ///  累计消费钻石
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diamondConsume;
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