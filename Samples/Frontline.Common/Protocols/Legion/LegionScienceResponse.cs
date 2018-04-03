using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 科技列表 协议:-365
    /// </summary>
	[Proto(value=-365,description="科技列表")]
	[ProtoContract]
	public class LegionScienceResponse
	{
        /// <summary>
        ///  军团科技列表
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<LegionScienceInfo> LegionSciences;
    }
}