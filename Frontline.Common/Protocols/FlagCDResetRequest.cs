using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 竞技场时间重置 协议:153
    /// </summary>
	[Proto(value=153,description="竞技场时间重置")]
	[ProtoContract]
	public class FlagCDResetRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}