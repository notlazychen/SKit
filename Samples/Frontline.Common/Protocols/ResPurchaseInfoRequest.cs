using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 资源采购详情 协议:23
    /// </summary>
	[Proto(value=23,description="资源采购详情")]
	[ProtoContract]
	public class ResPurchaseInfoRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}