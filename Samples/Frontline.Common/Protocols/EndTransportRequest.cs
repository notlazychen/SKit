using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 结束运输玩法 协议:622
    /// </summary>
	[Proto(value=622,description="结束运输玩法")]
	[ProtoContract]
	public class EndTransportRequest
	{
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string battleToken;
        /// <summary>
        ///  消耗的技能的id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<string> usedSkills;
        /// <summary>
        ///  remainTruckHP
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<int> remainTruckHP;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<FightUnitInfo> units;
        /// <summary>
        ///  是否胜利
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool win;

	}
}