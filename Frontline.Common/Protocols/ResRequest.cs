using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 资源查看 协议:9
    /// </summary>
	[Proto(value=9,description="资源查看")]
	[ProtoContract]
	public class ResRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}