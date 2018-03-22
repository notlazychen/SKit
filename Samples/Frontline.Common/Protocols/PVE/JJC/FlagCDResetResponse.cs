using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 竞技场时间重置 协议:-153
    /// </summary>
	[Proto(value=-153,description="竞技场时间重置")]
	[ProtoContract]
	public class FlagCDResetResponse
	{
        /// <summary>
        ///  冷却截止时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long nextTime;
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