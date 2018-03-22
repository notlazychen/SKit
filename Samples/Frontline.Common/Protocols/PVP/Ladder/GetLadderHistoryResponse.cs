using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取天梯战斗记录返回 协议:-602
    /// </summary>
	[Proto(value=-602,description="获取天梯战斗记录返回")]
	[ProtoContract]
	public class GetLadderHistoryResponse
	{
        /// <summary>
        ///  战斗记录
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<LadderBattleInfo> battles;
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