using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 工厂升级加速返回 协议:-106
    /// </summary>
	[Proto(value=-106,description="工厂升级加速返回")]
	[ProtoContract]
	public class BuildSpdUpResponse
	{
        /// <summary>
        ///  升级道具Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  升级道具剩余数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int itemCnt;
        /// <summary>
        ///  diamond
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  工厂
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
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