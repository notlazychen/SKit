using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 绑定账号完成 协议:1002
    /// </summary>
	[Proto(value=1002,description="绑定账号完成")]
	[ProtoContract]
	public class BindPlayerRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string pid;

	}
}