using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 离开房间 协议:-1305
    /// </summary>
	[Proto(value=-1305,description="离开房间")]
	[ProtoContract]
	public class ExitRoomResponse
	{
        /// <summary>
        ///  房间id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string roomId;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}