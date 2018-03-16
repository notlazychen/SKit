using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看战斗记录 协议:-822
    /// </summary>
	[Proto(value=-822,description="查看战斗记录")]
	[ProtoContract]
	public class GVGBattleHistoriesResponse
	{
        /// <summary>
        ///  战斗记录
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<GVGBattleInfo> histories;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}