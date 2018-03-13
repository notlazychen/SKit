using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看自己的详细信息 协议:816
    /// </summary>
	[Proto(value=816,description="查看自己的详细信息")]
	[ProtoContract]
	public class PlayerDetailRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}