using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 发言 协议:362
    /// </summary>
	[Proto(value=362,description="发言")]
	[ProtoContract]
	public class TalkOnBBSRequest
	{
        /// <summary>
        ///  内容
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string message;

	}
}