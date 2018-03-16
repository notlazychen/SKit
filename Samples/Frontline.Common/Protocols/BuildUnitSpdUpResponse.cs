using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 加速休整返回 协议:-18
    /// </summary>
	[Proto(value=-18,description="加速休整返回")]
	[ProtoContract]
	public class BuildUnitSpdUpResponse
	{
        /// <summary>
        ///  兵种id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string unitId;
        /// <summary>
        ///  休整结束时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long endTime;
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