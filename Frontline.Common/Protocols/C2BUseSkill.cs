using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）请求使用技能 协议:505
    /// </summary>
	[Proto(value=505,description="（战斗服）请求使用技能")]
	[ProtoContract]
	public class C2BUseSkill
	{
        /// <summary>
        ///  释放技能的单位id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string uid;
        /// <summary>
        ///  要使用的技能Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int skillId;
        /// <summary>
        ///  施放坐标
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public V3 position;

	}
}