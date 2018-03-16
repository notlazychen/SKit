using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 使用物品 协议:-35
    /// </summary>
	[Proto(value=-35,description="使用物品")]
	[ProtoContract]
	public class UseItemResponse
	{
        /// <summary>
        ///  被使用的物品的id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  被使用的物品使用后的数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int lap;
        /// <summary>
        ///  使用后获得的资源和物品集合
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public RewardInfo rewardInfo;
        /// <summary>
        ///  使用后解锁的兵种
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public UnitInfo unitInfo;
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