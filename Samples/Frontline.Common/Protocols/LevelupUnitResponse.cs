using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级单位 协议:-29
    /// </summary>
	[Proto(value=-29,description="升级单位")]
	[ProtoContract]
	public class LevelupUnitResponse
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  剩余的军需/钢铁资源
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int supply;
        /// <summary>
        ///  剩余的军需/钢铁资源
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int iron;
        /// <summary>
        ///  升级后的unitInfo
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public UnitInfo unitInfo;
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