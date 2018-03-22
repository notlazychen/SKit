using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）造成伤害 协议:-502
    /// </summary>
	[Proto(value=-502,description="（战斗服）造成伤害")]
	[ProtoContract]
	public class B2CDamage
	{
        /// <summary>
        ///  输出的技能ID，如果是作战单位输出则为0
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int skillId;
        /// <summary>
        ///  输出的单兵Id，如果是技能输出则为null
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string attackGoId;
        /// <summary>
        ///  收到伤害的单兵Id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string hurtGoId;
        /// <summary>
        ///  伤害量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int damage;
        /// <summary>
        ///  hurtType
        /// </summary>
		[ProtoMember(6, IsRequired = true)]
		public int hurtType;
        /// <summary>
        ///  是否暴击
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public bool isBaoji;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}