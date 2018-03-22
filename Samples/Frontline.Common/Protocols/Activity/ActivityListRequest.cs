using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查询活动类型列表 协议:700
    /// </summary>
	[Proto(value=700,description="查询活动类型列表")]
	[ProtoContract]
	public class ActivityListRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}