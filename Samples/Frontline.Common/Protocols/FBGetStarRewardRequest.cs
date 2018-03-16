using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求副本星星奖励信息 协议:74
    /// </summary>
	[Proto(value=74,description="请求副本星星奖励信息")]
	[ProtoContract]
	public class FBGetStarRewardRequest
	{
        /// <summary>
        ///  章节
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int section;
        /// <summary>
        ///  副本类型1普通2精英
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;
        /// <summary>
        ///  欲领取的奖励序号
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int reward;

	}
}