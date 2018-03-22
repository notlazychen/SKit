using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 快速进入房间 协议:1314
    /// </summary>
	[Proto(value=1314,description="快速进入房间")]
	[ProtoContract]
	public class QuickEnterRoomRequest
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