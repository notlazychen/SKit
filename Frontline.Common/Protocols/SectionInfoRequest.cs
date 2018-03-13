using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 章 协议:42
    /// </summary>
	[Proto(value=42,description="章")]
	[ProtoContract]
	public class SectionInfoRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}