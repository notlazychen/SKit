using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 更换房主 协议:-1307
    /// </summary>
	[Proto(value=-1307,description="更换房主")]
	[ProtoContract]
	public class ChangeRoomOwnerResponse
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
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