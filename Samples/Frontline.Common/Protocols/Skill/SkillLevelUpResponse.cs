using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级技能 协议:-27
    /// </summary>
	[Proto(value=-27,description="升级技能")]
	[ProtoContract]
	public class SkillLevelUpResponse
	{
        /// <summary>
        ///  技能id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int sid;
        /// <summary>
        ///  当前等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int lv;

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