using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵工厂详情 协议:-16
    /// </summary>
	[Proto(value=-16,description="兵工厂详情")]
	[ProtoContract]
	public class FactoryResponse
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