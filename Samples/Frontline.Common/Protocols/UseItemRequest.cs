using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 使用物品（有可能解锁兵种或随机包） 协议:35
    /// </summary>
	[Proto(value=35,description="使用物品（有可能解锁兵种或随机包）")]
	[ProtoContract]
	public class UseItemRequest
	{
        /// <summary>
        ///  物品id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  使用物品数量
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int cnt;

	}
}