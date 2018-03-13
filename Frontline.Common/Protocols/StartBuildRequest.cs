using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级工厂 协议:104
    /// </summary>
	[Proto(value=104,description="升级工厂")]
	[ProtoContract]
	public class StartBuildRequest
	{
        /// <summary>
        ///  工厂type
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  是否立即完成（使用钻石）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool immediately;

	}
}