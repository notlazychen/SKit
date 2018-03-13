using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 扫荡 协议:73
    /// </summary>
	[Proto(value=73,description="扫荡")]
	[ProtoContract]
	public class ResistSweepRequest
	{
        /// <summary>
        ///  1普通扫荡，2强化扫荡
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int mode;

	}
}