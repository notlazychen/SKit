using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求大厅信息 协议:-1301
    /// </summary>
	[Proto(value=-1301,description="请求大厅信息")]
	[ProtoContract]
	public class HallInfoResponse
	{
        /// <summary>
        ///  房间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<RoomInfo> rooms;
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