using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 战斗开始确定 协议:-123
    /// </summary>
	[Proto(value=-123,description="战斗开始确定")]
	[ProtoContract]
	public class MatchBattleConfirmResponse
	{
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