using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 离开房间 协议:1305
    /// </summary>
	[Proto(value=1305,description="离开房间")]
	[ProtoContract]
	public class ExitRoomRequest
	{
        /// <summary>
        ///  房间id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string roomId;

	}
}