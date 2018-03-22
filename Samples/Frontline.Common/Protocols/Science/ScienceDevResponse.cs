using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 研发科技返回 协议:-12
    /// </summary>
	[Proto(value=-12,description="研发科技返回")]
	[ProtoContract]
	public class ScienceDevResponse
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
        ///  level
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int level;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  iron
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int iron;
        /// <summary>
        ///  gold
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  supply
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int supply;
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