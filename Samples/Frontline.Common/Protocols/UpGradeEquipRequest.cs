using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 装备升阶 协议:40
    /// </summary>
	[Proto(value=40,description="装备升阶")]
	[ProtoContract]
	public class UpGradeEquipRequest
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

	}
}