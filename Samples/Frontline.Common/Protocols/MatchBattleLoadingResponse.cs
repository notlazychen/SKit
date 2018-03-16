using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）读条返回 协议:-125
    /// </summary>
	[Proto(value=-125,description="（战斗服）读条返回")]
	[ProtoContract]
	public class MatchBattleLoadingResponse
	{
        /// <summary>
        ///  对方的pid
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public string pid;
        /// <summary>
        ///  对方的进度
        /// </summary>
		[ProtoMember(4, IsRequired = true)]
		public int progress;
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