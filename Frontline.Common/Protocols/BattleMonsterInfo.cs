using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class BattleMonsterInfo
	{
        /// <summary>
        ///  tid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int tid;
        /// <summary>
        ///  monsterInfo
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public MonsterInfo monsterInfo;
        /// <summary>
        ///  gos
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<PVPBattleUnitGameObject> gos;

	}
}