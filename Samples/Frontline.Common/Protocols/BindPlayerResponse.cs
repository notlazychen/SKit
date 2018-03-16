using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 绑定账号完成 协议:-1002
    /// </summary>
	[Proto(value=-1002,description="绑定账号完成")]
	[ProtoContract]
	public class BindPlayerResponse
	{
        /// <summary>
        ///  角色id
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