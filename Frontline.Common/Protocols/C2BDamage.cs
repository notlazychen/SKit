using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）造成伤害 协议:502
    /// </summary>
	[Proto(value=502,description="（战斗服）造成伤害")]
	[ProtoContract]
	public class C2BDamage
	{
        /// <summary>
        ///  输出的技能ID，如果是作战单位输出则为0
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int skillId;
        /// <summary>
        ///  输出的单兵Id，如果是技能输出则为null
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string attackGoId;
        /// <summary>
        ///  hurtType
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public int hurtType;
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
        ///  攻击序号
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int index;
        /// <summary>
        ///  是否暴击
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public bool isBaoji;

	}
}