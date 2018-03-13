using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵营查看 协议:14
    /// </summary>
	[Proto(value=14,description="兵营查看")]
	[ProtoContract]
	public class UnitListRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}