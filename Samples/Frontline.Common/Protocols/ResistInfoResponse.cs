using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 抵抗前线的返回值 协议:-70
    /// </summary>
	[Proto(value=-70,description="抵抗前线的返回值")]
	[ProtoContract]
	public class ResistInfoResponse
	{
        /// <summary>
        ///  最高波数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int best;
        /// <summary>
        ///  当前波数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int current;
        /// <summary>
        ///  剩余重置次数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int resetNumb;
        /// <summary>
        ///  已领取的宝箱Id
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<int> recvBoxes;
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