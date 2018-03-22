using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 移动坐标 协议:599
    /// </summary>
	[Proto(value=599,description="移动坐标")]
	[ProtoContract]
	public class MovePositionUpload
	{
        /// <summary>
        ///  单位名
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string name;
        /// <summary>
        ///  坐标
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public V3 position;

	}
}