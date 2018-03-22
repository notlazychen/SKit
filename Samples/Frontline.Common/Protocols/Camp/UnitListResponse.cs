using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看兵营的返回 协议:-14
    /// </summary>
	[Proto(value=-14,description="查看兵营的返回")]
	[ProtoContract]
	public class UnitListResponse
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  单位集合
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<UnitInfo> units;
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