using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 抵抗前线详情 协议:70
    /// </summary>
	[Proto(value=70,description="抵抗前线详情")]
	[ProtoContract]
	public class ResistInfoRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}