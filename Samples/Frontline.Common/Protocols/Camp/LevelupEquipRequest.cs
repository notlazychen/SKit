using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级装备 协议:39
    /// </summary>
	[Proto(value=39,description="升级装备")]
	[ProtoContract]
	public class LevelupEquipRequest
	{
        /// <summary>
        ///  兵种id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int unitId;
        /// <summary>
        ///  装备部位
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int position;
        /// <summary>
        ///  是否一键升级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool multy;

	}
}