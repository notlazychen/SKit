using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求夺旗战对战记录 协议:145
    /// </summary>
	[Proto(value=145,description="请求夺旗战对战记录")]
	[ProtoContract]
	public class GrabFlagBattleHistoryRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}