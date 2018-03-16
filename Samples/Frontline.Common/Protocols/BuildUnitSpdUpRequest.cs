using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 休整加速 协议:18
    /// </summary>
	[Proto(value=18,description="休整加速")]
	[ProtoContract]
	public class BuildUnitSpdUpRequest
	{
        /// <summary>
        ///  单位id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string unitId;
        /// <summary>
        ///  加速道具id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  道具数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int itemCnt;

	}
}