using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 结束雪地营救 协议:223
    /// </summary>
	[Proto(value=223,description="结束雪地营救")]
	[ProtoContract]
	public class EndRescueRequest
	{
        /// <summary>
        ///  battleId
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string battleId;
        /// <summary>
        ///  是否胜利
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  消耗的技能id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<string> usedSkills;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<FightUnitInfo> units;

	}
}