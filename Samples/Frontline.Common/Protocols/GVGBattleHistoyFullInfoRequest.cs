using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看公会战斗记录详情 协议:823
    /// </summary>
	[Proto(value=823,description="查看公会战斗记录详情")]
	[ProtoContract]
	public class GVGBattleHistoyFullInfoRequest
	{
        /// <summary>
        ///  战斗记录id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string battleId;

	}
}