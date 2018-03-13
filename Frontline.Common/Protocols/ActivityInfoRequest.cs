using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求活动数据 协议:701
    /// </summary>
	[Proto(value=701,description="请求活动数据")]
	[ProtoContract]
	public class ActivityInfoRequest
	{
        /// <summary>
        ///  活动类型(1连续登录，2充值返利，3冲级奖励，4首充礼包)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  页签
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tag;

	}
}