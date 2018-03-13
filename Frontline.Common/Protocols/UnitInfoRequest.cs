using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看unit信息 协议:31
    /// </summary>
	[Proto(value=31,description="查看unit信息")]
	[ProtoContract]
	public class UnitInfoRequest
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string id;
        /// <summary>
        ///  等级（0表示当前等级）
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int level;
        /// <summary>
        ///  阶（0表示当前阶）
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int claz;

	}
}