using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 提交派遣任务
    /// </summary>
	[Proto(value=-20007,description= "提交派遣任务")]
	[ProtoContract]
	public class FinishWorkResponse
    {
        [ProtoMember(1, IsRequired = false)]
        public bool success;
        [ProtoMember(2, IsRequired = false)]
        public string info;
        
        [ProtoMember(3, IsRequired = false)]
		public WorkTaskInfo taskInfo;
        [ProtoMember(4, IsRequired = false)]
        public RewardInfo rewardInfo;
    }
}