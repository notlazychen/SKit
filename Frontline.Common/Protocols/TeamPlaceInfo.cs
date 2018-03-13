using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class TeamPlaceInfo
	{
        /// <summary>
        ///  单位详情
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public UnitInfo unitInfo;
        /// <summary>
        ///  单位在阵型中的位置
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int place;

	}
}