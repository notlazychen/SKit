using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求全部活动数据 协议:704
    /// </summary>
	[Proto(value=704,description="请求全部活动数据")]
	[ProtoContract]
	public class ActivityAllInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}