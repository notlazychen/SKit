using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 更换房主 协议:1307
    /// </summary>
	[Proto(value=1307,description="更换房主")]
	[ProtoContract]
	public class ChangeRoomOwnerRequest
	{
        /// <summary>
        ///  新房主pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}