using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 商城详情 协议:130
    /// </summary>
	[Proto(value=130,description="商城详情")]
	[ProtoContract]
	public class MallInfoRequest
	{
        /// <summary>
        ///  玩家id，null表示本人
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}