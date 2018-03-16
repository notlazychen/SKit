using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求当前主线 协议:-330
    /// </summary>
	[Proto(value=-330,description="请求当前主线")]
	[ProtoContract]
	public class MainlineResponse
	{
        /// <summary>
        ///  当前章节
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int chapter;
        /// <summary>
        ///  是否已提交（正常提交后会刷出下一章，特殊情况全部完成才会为true）
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool finished;
        /// <summary>
        ///  分支线任务
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
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