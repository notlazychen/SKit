using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）验证 协议:508
    /// </summary>
	[Proto(value=508,description="（战斗服）验证")]
	[ProtoContract]
	public class C2BAuth
	{
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string token;

	}
}