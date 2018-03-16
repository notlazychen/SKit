using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 创建角色的response 协议:-8
    /// </summary>
	[Proto(value=-8,description="创建角色的response")]
	[ProtoContract]
	public class CreatePlayerResponse
	{
        /// <summary>
        ///  创建的角色id
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