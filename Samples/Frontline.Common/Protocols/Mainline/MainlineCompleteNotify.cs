using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 主线任务完成推送 协议:-332
    /// </summary>
	[Proto(value=-332,description="主线任务完成推送")]
	[ProtoContract]
	public class MainlineCompleteNotify
	{
        /// <summary>
        ///  当前主线id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int curId;
        /// <summary>
        ///  新的主线id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int newId;
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