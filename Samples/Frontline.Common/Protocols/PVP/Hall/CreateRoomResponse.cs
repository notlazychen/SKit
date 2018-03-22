using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开房间 协议:-1302
    /// </summary>
	[Proto(value=-1302,description="开房间")]
	[ProtoContract]
	public class CreateRoomResponse
	{
        /// <summary>
        ///  玩法类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int diff;
        /// <summary>
        ///  房间id
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
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