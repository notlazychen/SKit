using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 引导情况 协议:101
    /// </summary>
	[Proto(value=101,description="引导情况")]
	[ProtoContract]
	public class GuideInfoRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}