using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看公会战斗记录 协议:822
    /// </summary>
	[Proto(value=822,description="查看公会战斗记录")]
	[ProtoContract]
	public class GVGBattleHistoriesRequest
	{
        /// <summary>
        ///  本公会id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;

	}
}