using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 取消建造返回 协议:-105
    /// </summary>
	[Proto(value=-105,description="取消建造返回")]
	[ProtoContract]
	public class CancelBuildResponse
	{
        /// <summary>
        ///  工厂
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
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