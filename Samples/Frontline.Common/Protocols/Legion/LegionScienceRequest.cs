using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 科技列表 协议:365
    /// </summary>
	[Proto(value=365,description="科技列表")]
	[ProtoContract]
	public class LegionScienceRequest
	{
        /// <summary>
        ///  军团id, 并没什么软用
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string legionId;
	}
}