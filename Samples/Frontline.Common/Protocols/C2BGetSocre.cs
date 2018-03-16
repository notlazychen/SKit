using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）请求同步分数 协议:503
    /// </summary>
	[Proto(value=503,description="（战斗服）请求同步分数")]
	[ProtoContract]
	public class C2BGetSocre
	{
        /// <summary>
        ///  nothing
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string nothing;

	}
}