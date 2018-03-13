using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 作弊 协议:200
    /// </summary>
	[Proto(value=200,description="作弊")]
	[ProtoContract]
	public class CheatRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  行为 （例设置军需伪10000： setres,1,10000）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string action;

	}
}