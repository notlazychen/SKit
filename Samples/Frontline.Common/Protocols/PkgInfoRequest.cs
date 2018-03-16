using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 背包详情 协议:32
    /// </summary>
	[Proto(value=32,description="背包详情")]
	[ProtoContract]
	public class PkgInfoRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}