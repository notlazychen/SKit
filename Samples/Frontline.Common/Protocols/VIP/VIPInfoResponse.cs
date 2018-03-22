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
		[ProtoMember(3, IsRequired = false)]
		public int vipLevel;
        /// <summary>
        ///  当前VIP经验
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int vipExp;
        /// <summary>
        ///  VIP升级所需经验
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int nextLvExp;
        /// <summary>
        ///  已领取的VIP礼包
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<int> receivedGifts;
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