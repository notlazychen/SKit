using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 检查我的开房信息 协议:-1315
    /// </summary>
	[Proto(value=-1315,description="检查我的开房信息")]
	[ProtoContract]
	public class CheckMyRoomInfoResponse
	{
        /// <summary>
        ///  如果我有房间的话不为null
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