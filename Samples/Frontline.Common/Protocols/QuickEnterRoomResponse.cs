using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 快速进入房间 协议:-1314
    /// </summary>
	[Proto(value=-1314,description="快速进入房间")]
	[ProtoContract]
	public class QuickEnterRoomResponse
	{
        /// <summary>
        ///  如果有房间则不为空
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