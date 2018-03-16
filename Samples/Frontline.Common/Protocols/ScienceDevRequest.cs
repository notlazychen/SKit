using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 研发科技 协议:12
    /// </summary>
	[Proto(value=12,description="研发科技")]
	[ProtoContract]
	public class ScienceDevRequest
	{
        /// <summary>
        ///  科技id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int id;
        /// <summary>
        ///  是否直接钻石购买
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool buy;
        /// <summary>
        ///  是否取消
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool cancel;

	}
}