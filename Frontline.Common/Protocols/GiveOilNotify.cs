using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收到好友赠送原油通知 协议:-310
    /// </summary>
	[Proto(value=-310,description="收到好友赠送原油通知")]
	[ProtoContract]
	public class GiveOilNotify
	{
        /// <summary>
        ///  好友id
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