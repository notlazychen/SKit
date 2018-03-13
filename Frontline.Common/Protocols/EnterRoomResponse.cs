using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求进入房间 协议:-1304
    /// </summary>
	[Proto(value=-1304,description="请求进入房间")]
	[ProtoContract]
	public class EnterRoomResponse
	{
        /// <summary>
        ///  房间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RoomInfo room;
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