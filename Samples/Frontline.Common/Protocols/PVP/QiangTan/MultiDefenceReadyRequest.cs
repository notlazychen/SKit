using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）抢滩保卫战，准备完毕 协议:656
    /// </summary>
	[Proto(value=656,description="（战斗服）抢滩保卫战，准备完毕")]
	[ProtoContract]
	public class MultiDefenceReadyRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}