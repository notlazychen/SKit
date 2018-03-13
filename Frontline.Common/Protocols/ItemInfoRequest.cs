using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看物品配置详情 协议:53
    /// </summary>
	[Proto(value=53,description="查看物品配置详情")]
	[ProtoContract]
	public class ItemInfoRequest
	{
        /// <summary>
        ///  物品id(策划)
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int id;

	}
}