using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 处理入党申请 协议:355
    /// </summary>
	[Proto(value=355,description="处理入党申请")]
	[ProtoContract]
	public class ProcessApplyRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否通过
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool pass;

	}
}