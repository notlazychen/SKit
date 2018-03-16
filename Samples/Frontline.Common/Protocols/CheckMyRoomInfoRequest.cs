using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 检查我的开房信息 协议:1315
    /// </summary>
	[Proto(value=1315,description="检查我的开房信息")]
	[ProtoContract]
	public class CheckMyRoomInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}