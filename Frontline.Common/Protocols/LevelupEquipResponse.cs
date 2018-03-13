using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级装备 协议:-39
    /// </summary>
	[Proto(value=-39,description="升级装备")]
	[ProtoContract]
	public class LevelupEquipResponse
	{
        /// <summary>
        ///  equip id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  兵种id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string unitid;
        /// <summary>
        ///  升级后的等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int level;
        /// <summary>
        ///  剩余的金币
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  剩余的军需
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int supply;
        /// <summary>
        ///  剩余的钢铁
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int iron;
        /// <summary>
        ///  剩余的钻石
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  升级后的兵种信息
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public UnitInfo unitInfo;
        /// <summary>
        ///  消耗的物品的剩余数量
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public List<RemainItemInfo> items;
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