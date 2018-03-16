using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 上传战斗结果 协议:47
    /// </summary>
	[Proto(value=47,description="上传战斗结果")]
	[ProtoContract]
	public class FBFightResultRequest
	{
        /// <summary>
        ///  关卡ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  消耗的物品的id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<string> usedItems;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<FightUnitInfo> units;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string token;

	}
}