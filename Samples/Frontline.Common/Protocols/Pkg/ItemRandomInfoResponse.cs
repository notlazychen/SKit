using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看物品使用后获得的随机道具和资源 协议:-80
    /// </summary>
	[Proto(value=-80,description="查看物品使用后获得的随机道具和资源")]
	[ProtoContract]
	public class ItemRandomInfoResponse
	{
        /// <summary>
        ///  物品id集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<int> itemIds;
        /// <summary>
        ///  资源类型集合
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<int> ress;
        /// <summary>
        ///  资源数量集合
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<int> ressCnt;
        /// <summary>
        ///  是否全给
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool all;
        /// <summary>
        ///  物品数量集合
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<int> itemCnt;
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