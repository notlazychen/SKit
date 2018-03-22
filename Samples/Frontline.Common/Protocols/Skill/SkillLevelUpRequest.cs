using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级技能 协议:27
    /// </summary>
	[Proto(value=27,description="升级技能")]
	[ProtoContract]
	public class SkillLevelUpRequest
	{
        /// <summary>
        ///  技能id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int sid;

	}
}