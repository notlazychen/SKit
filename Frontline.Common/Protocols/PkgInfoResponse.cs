using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 背包 协议:-32
    /// </summary>
	[Proto(value=-32,description="背包")]
	[ProtoContract]
	public class PkgInfoResponse
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  背包内物品集合
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<ItemInfo> items;
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