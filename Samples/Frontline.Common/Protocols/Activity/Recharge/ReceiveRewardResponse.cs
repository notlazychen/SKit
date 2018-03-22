using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 充值信息返回 协议:-1203
    /// </summary>
	[Proto(value=-1203,description="充值信息返回")]
	[ProtoContract]
	public class ReceiveRewardResponse
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  type
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  奖励信息
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  当前钻石数量
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int diamond;
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