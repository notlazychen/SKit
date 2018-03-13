using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 申请入党 协议:-351
    /// </summary>
	[Proto(value=-351,description="申请入党")]
	[ProtoContract]
	public class ApplyPartyResponse
	{
        /// <summary>
        ///  申请的党的id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
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