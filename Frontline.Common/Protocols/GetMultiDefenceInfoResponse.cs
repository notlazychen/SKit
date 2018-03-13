using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查询抢滩战信息返回 协议:-653
    /// </summary>
	[Proto(value=-653,description="查询抢滩战信息返回")]
	[ProtoContract]
	public class GetMultiDefenceInfoResponse
	{
        /// <summary>
        ///  总积分
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int score;
        /// <summary>
        ///  已兑换的兵种Id集合
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<int> ownedUnits;
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