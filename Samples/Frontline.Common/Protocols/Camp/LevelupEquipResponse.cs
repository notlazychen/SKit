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
        ///  兵种id
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int unitId;
        /// <summary>
        ///  装备部位
        /// </summary>
		[ProtoMember(4, IsRequired = true)]
		public int position;
        /// <summary>
        ///  升级后的装备信息
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public EquipInfo equipInfo;
        /// <summary>
        ///  升级后的兵种信息
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