using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 提交派遣任务
    /// </summary>
	[Proto(value=20007,description= "提交派遣任务")]
	[ProtoContract]
	public class FinishWorkRequest
    {
        [ProtoMember(1, IsRequired = false)]
        public string taskid;
        /// <summary>
        /// 使用道具立即完成
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
        public bool useItem;
    }
}