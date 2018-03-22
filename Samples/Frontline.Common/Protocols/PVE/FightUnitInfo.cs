using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class FightUnitInfo
	{
        /// <summary>
        ///  战死
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool dead;
        /// <summary>
        ///  兵种Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string unitId;
        /// <summary>
        ///  剩余耐久点数
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int remainNumber;
        /// <summary>
        ///  经验
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int lv;

	}
}