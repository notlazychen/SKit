using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 七日福利信息 协议:713
    /// </summary>
	[Proto(value=713,description="七日福利信息")]
	[ProtoContract]
	public class QiRiInfoRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}