using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 所有充值信息返回 协议:-1202
    /// </summary>
	[Proto(value=-1202,description="所有充值信息返回")]
	[ProtoContract]
	public class RechargeAllResponse
	{
        /// <summary>
        ///  充值活动信息
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<RechargeTagDetail> details;
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