using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 资源采购详情 协议:-23
    /// </summary>
	[Proto(value=-23,description="资源采购详情")]
	[ProtoContract]
	public class ResPurchaseInfoResponse
	{
        /// <summary>
        ///  资源购买详情
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<BuyResInfo> buyResInfos;
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