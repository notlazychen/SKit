using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 军队召回 协议:-828
    /// </summary>
	[Proto(value=-828,description="军队召回")]
	[ProtoContract]
	public class ArmyBackResponse
	{
        /// <summary>
        ///  army
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public ArmyInfo army;
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