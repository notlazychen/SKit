using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 派遣任务
    /// </summary>
	[ProtoContract]
	public class WorkTaskInfo
    {
        [ProtoMember(5, IsRequired = false)]
        public String Id;

        [ProtoMember(1, IsRequired = false)]
        public int Tid;
        /// <summary>
        /// 派遣中的工人Id
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
		public List<string> Workers;
        /// <summary>
        /// 0 未派遣, 1已派遣, 2已完成
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int State;
        /// <summary>
        /// 派遣结束时间
        /// </summary>
        [ProtoMember(4, IsRequired = false)]
        public long EndTime;
    }
}