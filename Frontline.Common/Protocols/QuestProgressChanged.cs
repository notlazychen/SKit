using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 任务进度改变 协议:-111
    /// </summary>
	[Proto(value=-111,description="任务进度改变")]
	[ProtoContract]
	public class QuestProgressChanged
	{
        /// <summary>
        ///  questInfo
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public QuestInfo questInfo;
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