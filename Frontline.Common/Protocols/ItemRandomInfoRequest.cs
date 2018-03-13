using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看物品使用后获得的随机道具 协议:80
    /// </summary>
	[Proto(value=80,description="查看物品使用后获得的随机道具")]
	[ProtoContract]
	public class ItemRandomInfoRequest
	{
        /// <summary>
        ///  物品id(策划)
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int id;

	}
}