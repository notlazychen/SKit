using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 挑战请求返回 协议:-144
    /// </summary>
	[Proto(value=-144,description="挑战请求返回")]
	[ProtoContract]
	public class GrabFlagBattleChallengeResponse
	{
        /// <summary>
        ///  敌方的单位
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<UnitInfo> adversaryUnits;
        /// <summary>
        ///  我方的单位
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<UnitInfo> myUnits;
        /// <summary>
        ///  本次战斗的Id
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string battleId;
        /// <summary>
        ///  对方的名字
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string enemyName;
        /// <summary>
        ///  剩余挑战次数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int remainChallengeTimes;
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