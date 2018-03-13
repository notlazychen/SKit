using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 天梯信息返回 协议:-600
    /// </summary>
	[Proto(value=-600,description="天梯信息返回")]
	[ProtoContract]
	public class GetLadderInfoResponse
	{
        /// <summary>
        ///  军衔
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int militaryRank;
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(4, IsRequired = true)]
		public int ladderScore;
        /// <summary>
        ///  普通匹配剩余次数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int normalNumber;
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