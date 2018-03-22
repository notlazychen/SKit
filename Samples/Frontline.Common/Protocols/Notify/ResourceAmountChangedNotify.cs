using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 物品数量改变的推送 协议:-114
    /// </summary>
	[Proto(value=-114,description="物品数量改变的推送")]
	[ProtoContract]
	public class ResourceAmountChangedNotify
	{
        /// <summary>
        ///  数量改变的物品集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<ResourceInfo> items;
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