using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 装备升阶 协议:-40
    /// </summary>
	[Proto(value=-40,description="装备升阶")]
	[ProtoContract]
	public class UpGradeEquipResponse
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
        ///  升阶后的装备信息
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public EquipInfo equipInfo;
        /// <summary>
        ///  升阶后的兵种信息
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