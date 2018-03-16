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
        ///  equip id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string id;
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string unitid;
        /// <summary>
        ///  是否一键升级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool multy;

	}
}