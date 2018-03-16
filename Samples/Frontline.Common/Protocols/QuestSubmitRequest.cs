using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 提交任务 协议:112
    /// </summary>
	[Proto(value=112,description="提交任务")]
	[ProtoContract]
	public class QuestSubmitRequest
	{
        /// <summary>
        ///  提交的任务编号
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  任务类型（0主线，1每日）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int questType;

	}
}