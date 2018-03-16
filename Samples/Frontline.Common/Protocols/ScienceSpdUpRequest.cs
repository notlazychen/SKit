using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 加速研发 协议:13
    /// </summary>
	[Proto(value=13,description="加速研发")]
	[ProtoContract]
	public class ScienceSpdUpRequest
	{
        /// <summary>
        ///  科技id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int id;
        /// <summary>
        ///  使用的加速道具ID
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int itemId;
        /// <summary>
        ///  使用的加速道具数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int itemCnt;

	}
}