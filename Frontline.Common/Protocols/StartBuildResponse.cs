using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级工厂返回 协议:-104
    /// </summary>
	[Proto(value=-104,description="升级工厂返回")]
	[ProtoContract]
	public class StartBuildResponse
	{
        /// <summary>
        ///  是否立即完成（使用钻石）
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool immediately;
        /// <summary>
        ///  工厂
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public FactoryInfo factoryInfo;
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