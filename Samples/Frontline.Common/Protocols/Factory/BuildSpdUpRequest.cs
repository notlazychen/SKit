using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 工厂升级加速 协议:106
    /// </summary>
	[Proto(value=106,description="工厂升级加速")]
	[ProtoContract]
	public class BuildSpdUpRequest
	{
        /// <summary>
        ///  工厂type
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  加速道具Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  使用的加速道具数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int itemCnt;

	}
}