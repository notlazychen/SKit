using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级单位 协议:29
    /// </summary>
	[Proto(value=29,description="升级单位")]
	[ProtoContract]
	public class LevelupUnitRequest
	{
        /// <summary>
        ///  unit id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string id;
        /// <summary>
        ///  是否一键升级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool adv;

	}
}