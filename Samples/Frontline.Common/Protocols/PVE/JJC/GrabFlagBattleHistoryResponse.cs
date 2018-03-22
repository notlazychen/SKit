using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 夺旗战对战记录返回 协议:-145
    /// </summary>
	[Proto(value=-145,description="夺旗战对战记录返回")]
	[ProtoContract]
	public class GrabFlagBattleHistoryResponse
	{
        /// <summary>
        ///  记录
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<GrabFlagBattleHistoryInfo> histories;
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