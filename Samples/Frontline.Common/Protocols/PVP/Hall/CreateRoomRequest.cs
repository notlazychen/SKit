using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开房间 协议:1302
    /// </summary>
	[Proto(value=1302,description="开房间")]
	[ProtoContract]
	public class CreateRoomRequest
	{
        /// <summary>
        ///  玩法类型
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int diff;

	}
}