using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 任务进度加载 协议:-110
    /// </summary>
	[Proto(value=-110,description="任务进度加载")]
	[ProtoContract]
	public class QuestInfoResponse
	{
        /// <summary>
        ///  任务集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<QuestInfo> quests;
        /// <summary>
        ///  当前的每日任务活跃点
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int questPoint;
        /// <summary>
        ///  每日任务活跃点奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<QuestPointRewardInfo> questPointRewards;
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