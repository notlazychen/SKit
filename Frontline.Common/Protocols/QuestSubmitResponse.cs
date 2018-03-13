using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 提交任务 协议:-112
    /// </summary>
	[Proto(value=-112,description="提交任务")]
	[ProtoContract]
	public class QuestSubmitResponse
	{
        /// <summary>
        ///  提交的任务编号
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  任务类型（0主线，1每日
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
        /// <summary>
        ///  当前的每日任务活跃点
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int questPoint;
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