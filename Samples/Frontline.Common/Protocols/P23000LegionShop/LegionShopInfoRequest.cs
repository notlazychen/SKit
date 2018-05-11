using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 军团商店详情 协议:23001
    /// </summary>
	[Proto(value=23001,description= "军团商店详情")]
	[ProtoContract]
	public class LegionShopInfoRequest
	{
        /// <summary>
        ///  玩家id，null表示本人
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}