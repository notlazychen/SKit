using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 夺旗积分奖励返回 协议:-146
    /// </summary>
	[Proto(value=-146,description="夺旗积分奖励返回")]
	[ProtoContract]
	public class GrabFlagScoreResponse
	{
        /// <summary>
        ///  当前积分
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int score;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<GrabFlagScoreInfo> scoreInfos;
        /// <summary>
        ///  冷却截止时间
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public long nextTime;
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