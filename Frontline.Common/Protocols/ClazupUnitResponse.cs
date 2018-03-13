using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 单位进阶 协议:-37
    /// </summary>
	[Proto(value=-37,description="单位进阶")]
	[ProtoContract]
	public class ClazupUnitResponse
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public string id;
        /// <summary>
        ///  剩余的金币
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  消耗的物品的id（策划）
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  消耗的物品的剩余数量
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int count;
        /// <summary>
        ///  unitInfo
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
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