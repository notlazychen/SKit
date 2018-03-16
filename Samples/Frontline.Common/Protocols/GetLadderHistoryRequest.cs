using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取天梯战斗记录 协议:602
    /// </summary>
	[Proto(value=602,description="获取天梯战斗记录")]
	[ProtoContract]
	public class GetLadderHistoryRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}