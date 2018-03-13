using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 维修主城 协议:830
    /// </summary>
	[Proto(value=830,description="维修主城")]
	[ProtoContract]
	public class GuildCityFixRequest
	{
        /// <summary>
        ///  是否使用钻石
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool useDiamond;

	}
}