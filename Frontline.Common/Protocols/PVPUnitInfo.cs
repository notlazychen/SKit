using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVPUnitInfo
	{
        /// <summary>
        ///  兵种策划id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int unitId;
        /// <summary>
        ///  兵种等级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int unitLv;
        /// <summary>
        ///  使用次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int useTimes;

	}
}