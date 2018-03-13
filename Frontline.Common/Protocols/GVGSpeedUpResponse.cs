using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）加速行军 协议:-807
    /// </summary>
	[Proto(value=-807,description="（公会战）加速行军")]
	[ProtoContract]
	public class GVGSpeedUpResponse
	{
        /// <summary>
        ///  部队
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public ArmyInfo armyInfo;
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