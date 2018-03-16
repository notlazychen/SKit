using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开始战斗 协议:1313
    /// </summary>
	[Proto(value=1313,description="开始战斗")]
	[ProtoContract]
	public class MultiPlayerBattleRequest
	{
        /// <summary>
        ///  开始战斗
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string nothing;

	}
}