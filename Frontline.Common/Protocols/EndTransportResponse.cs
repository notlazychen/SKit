using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 玩家的运输玩法数据 协议:-622
    /// </summary>
	[Proto(value=-622,description="玩家的运输玩法数据")]
	[ProtoContract]
	public class EndTransportResponse
	{
        /// <summary>
        ///  rewardInfo
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RewardInfo rewardInfo;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int difficultDegree;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<FightUnitInfo> units;
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