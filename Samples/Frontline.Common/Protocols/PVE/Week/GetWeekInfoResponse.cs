using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求周常信息 协议:-910
    /// </summary>
	[Proto(value=-910,description="请求周常信息")]
	[ProtoContract]
	public class GetWeekInfoResponse
	{
        /// <summary>
        ///  周几
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int day;
        /// <summary>
        ///  今日挑战次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int numb;
        /// <summary>
        ///  积分
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int score;
        /// <summary>
        ///  排名
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int rank;
        /// <summary>
        ///  已领取的宝箱
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<int> recevedBoxes;
        /// <summary>
        ///  本周挑战天数
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int battleDays;
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