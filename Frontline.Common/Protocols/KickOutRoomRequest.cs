using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 踢出成员 协议:1306
    /// </summary>
	[Proto(value=1306,description="踢出成员")]
	[ProtoContract]
	public class KickOutRoomRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}