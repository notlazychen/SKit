using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 攻打副本 协议:-45
    /// </summary>
	[Proto(value=-45,description="攻打副本")]
	[ProtoContract]
	public class FBFightResponse
	{
        /// <summary>
        ///  关卡ID(数据库id)
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string token;
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