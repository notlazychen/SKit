using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 技能列表 协议:-26
    /// </summary>
	[Proto(value=-26,description="技能列表")]
	[ProtoContract]
	public class SkillsInfoResponse
	{
        /// <summary>
        ///  技能集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<SkillInfo> skills;
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