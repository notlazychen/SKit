using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 回收兵种 协议:-251
    /// </summary>
	[Proto(value=-251,description="回收兵种")]
	[ProtoContract]
	public class ReclaimUnitResponse
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public string id;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  unitInfo
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public UnitInfo unitInfo;
        /// <summary>
        ///  回收获得
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public RewardInfo rewardInfo;
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