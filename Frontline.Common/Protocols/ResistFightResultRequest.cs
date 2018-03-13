using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 铁壁战波战斗结果上报 协议:72
    /// </summary>
	[Proto(value=72,description="铁壁战波战斗结果上报")]
	[ProtoContract]
	public class ResistFightResultRequest
	{
        /// <summary>
        ///  波id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int wid;
        /// <summary>
        ///  消耗的物品的id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<string> usedItems;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool win;

	}
}