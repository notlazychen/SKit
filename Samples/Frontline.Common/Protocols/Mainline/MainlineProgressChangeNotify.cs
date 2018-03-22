using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 主线任务进度改变推送 协议:-331
    /// </summary>
	[Proto(value=-331,description="主线任务进度改变推送")]
	[ProtoContract]
	public class MainlineProgressChangeNotify
	{
        /// <summary>
        ///  当前主线id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int mainlineId;
        /// <summary>
        ///  新的进度
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int progress;
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