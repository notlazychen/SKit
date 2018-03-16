using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收集物品数量推送 协议:-718
    /// </summary>
	[Proto(value=-718,description="收集物品数量推送")]
	[ProtoContract]
	public class CollectChangeNotify
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  当前收集物品数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int count;
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