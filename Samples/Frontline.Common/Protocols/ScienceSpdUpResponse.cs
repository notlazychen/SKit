using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 加速研发科技返回 协议:-13
    /// </summary>
	[Proto(value=-13,description="加速研发科技返回")]
	[ProtoContract]
	public class ScienceSpdUpResponse
	{
        /// <summary>
        ///  科技id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  研发结束时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long devEndTime;
        /// <summary>
        ///  消耗道具ID
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  消耗道具剩余数量
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int itemCnt;
        /// <summary>
        ///  diamond
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int diamond;
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