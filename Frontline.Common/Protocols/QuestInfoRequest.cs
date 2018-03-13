using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查询任务信息 协议:110
    /// </summary>
	[Proto(value=110,description="查询任务信息")]
	[ProtoContract]
	public class QuestInfoRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}