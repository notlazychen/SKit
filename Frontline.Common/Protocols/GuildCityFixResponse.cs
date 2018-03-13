using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 维修主城 协议:-830
    /// </summary>
	[Proto(value=-830,description="维修主城")]
	[ProtoContract]
	public class GuildCityFixResponse
	{
        /// <summary>
        ///  钻石
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  稀有金属
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int metal;
        /// <summary>
        ///  主城hp
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int hp;
        /// <summary>
        ///  是否钻石修理
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool useDiamond;
        /// <summary>
        ///  军功
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int feat;
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