using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求刷新商店 协议:137
    /// </summary>
	[Proto(value=137,description="请求刷新商店")]
	[ProtoContract]
	public class MallShopRefreshRequest
	{
        /// <summary>
        ///  玩家Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  商店类型
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;

	}
}