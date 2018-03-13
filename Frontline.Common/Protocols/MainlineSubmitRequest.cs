using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 提交主线任务 协议:333
    /// </summary>
	[Proto(value=333,description="提交主线任务")]
	[ProtoContract]
	public class MainlineSubmitRequest
	{
        /// <summary>
        ///  任务id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;

	}
}