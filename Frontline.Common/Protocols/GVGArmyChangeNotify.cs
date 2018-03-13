using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）地图中部队信息改变的通知 协议:-808
    /// </summary>
	[Proto(value=-808,description="（公会战）地图中部队信息改变的通知")]
	[ProtoContract]
	public class GVGArmyChangeNotify
	{
		[ProtoMember(3, IsRequired = false)]
		public int operation;
        /// <summary>
        ///  部队
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
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