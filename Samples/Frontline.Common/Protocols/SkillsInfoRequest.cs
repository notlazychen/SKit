using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 技能列表 协议:26
    /// </summary>
	[Proto(value=26,description="技能列表")]
	[ProtoContract]
	public class SkillsInfoRequest
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}