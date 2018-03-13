using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获取天梯信息 协议:600
    /// </summary>
	[Proto(value=600,description="获取天梯信息")]
	[ProtoContract]
	public class GetLadderInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string pid;

	}
}