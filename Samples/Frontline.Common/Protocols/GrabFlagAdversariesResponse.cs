using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 夺旗战的对手列表返回 协议:-142
    /// </summary>
	[Proto(value=-142,description="夺旗战的对手列表返回")]
	[ProtoContract]
	public class GrabFlagAdversariesResponse
	{
        /// <summary>
        ///  剩余挑战次数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int remainChallengTimes;
        /// <summary>
        ///  已购买次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int buyTimes;
        /// <summary>
        ///  当前排名
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int currentRank;
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int score;
        /// <summary>
        ///  对手
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<GrabFlagAdversaryInfo> adversaries;
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