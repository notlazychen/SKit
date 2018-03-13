using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 战斗结束推送 协议:-827
    /// </summary>
	[Proto(value=-827,description="战斗结束推送")]
	[ProtoContract]
	public class GVGBattleOverNotify
	{
        /// <summary>
        ///  战斗
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public GVGBattleInfo battleInfo;
        /// <summary>
        ///  军团荣誉
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int guildGlory;
        /// <summary>
        ///  军功
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int feat;
        /// <summary>
        ///  稀有金属
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int metal;
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