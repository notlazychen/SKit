using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 扫荡 协议:-73
    /// </summary>
	[Proto(value=-73,description="扫荡")]
	[ProtoContract]
	public class ResistSweepResponse
	{
        /// <summary>
        ///  1普通扫荡，2强化扫荡
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int mode;
        /// <summary>
        ///  当前波数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int current;
        /// <summary>
        ///  令牌奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int token;
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