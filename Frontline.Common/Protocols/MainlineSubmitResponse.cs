using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 提交主线任务 协议:-333
    /// </summary>
	[Proto(value=-333,description="提交主线任务")]
	[ProtoContract]
	public class MainlineSubmitResponse
	{
        /// <summary>
        ///  提交的任务序号
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int curId;
        /// <summary>
        ///  获得的奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  （如果提交的是主任务）新的章节
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int chapter;
        /// <summary>
        ///  主任务是否已提交
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool finished;
        /// <summary>
        ///  （如果提交的是主任务）刷新分支线任务
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<MainlineInfo> infos;
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