using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 取消升级建造 协议:105
    /// </summary>
	[Proto(value=105,description="取消升级建造")]
	[ProtoContract]
	public class CancelBuildRequest
	{
        /// <summary>
        ///  工厂type
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;

	}
}