using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 报名参加公会战 协议:803
    /// </summary>
	[Proto(value=803,description="报名参加公会战")]
	[ProtoContract]
	public class GVGEnrollRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}