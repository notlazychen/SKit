using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 重置波数 协议:76
    /// </summary>
	[Proto(value=76,description="重置波数")]
	[ProtoContract]
	public class ResistResetRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}