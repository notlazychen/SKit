using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 结束雪地营救 协议:-223
    /// </summary>
	[Proto(value=-223,description="结束雪地营救")]
	[ProtoContract]
	public class EndRescueResponse
	{
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  上阵单位
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
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