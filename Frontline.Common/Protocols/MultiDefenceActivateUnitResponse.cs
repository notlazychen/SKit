using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 激活兵种返回 协议:-654
    /// </summary>
	[Proto(value=-654,description="激活兵种返回")]
	[ProtoContract]
	public class MultiDefenceActivateUnitResponse
	{
        /// <summary>
        ///  总积分
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int score;
        /// <summary>
        ///  解锁的兵种
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int unitId;
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