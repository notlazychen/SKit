using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 申请入党 协议:351
    /// </summary>
	[Proto(value=351,description="申请入党")]
	[ProtoContract]
	public class ApplyPartyRequest
	{
        /// <summary>
        ///  申请的党的id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  申请的党的名字，两则必居其一
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string name;

	}
}