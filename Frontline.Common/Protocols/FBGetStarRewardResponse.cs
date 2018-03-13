using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求副本星星奖励信息返回 协议:-74
    /// </summary>
	[Proto(value=-74,description="请求副本星星奖励信息返回")]
	[ProtoContract]
	public class FBGetStarRewardResponse
	{
        /// <summary>
        ///  章节
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int section;
        /// <summary>
        ///  副本类型1普通2精英
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
        /// <summary>
        ///  领取到的钻石
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  已领取的星星奖励
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<int> receiveds;
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