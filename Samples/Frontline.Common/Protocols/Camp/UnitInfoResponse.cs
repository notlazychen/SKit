using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看unit信息 协议:-31
    /// </summary>
	[Proto(value=-31,description="查看unit信息")]
	[ProtoContract]
	public class UnitInfoResponse
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  等级（0表示当前等级）
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int level;
        /// <summary>
        ///  阶（0表示当前阶）
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int claz;
        /// <summary>
        ///  单位信息
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public UnitInfo unit;
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