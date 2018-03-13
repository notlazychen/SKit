using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVPBattleUnitGameObject
	{
        /// <summary>
        ///  goid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string name;
        /// <summary>
        ///  pos
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public V3 pos;
        /// <summary>
        ///  quat
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public Quaternion quat;
        /// <summary>
        ///  turrelQuat
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public Quaternion turrelQuat;
        /// <summary>
        ///  hp
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int hp;
        /// <summary>
        ///  inFiring
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool inFiring;
        /// <summary>
        ///  nextMovePos
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public V3 nextMovePos;
        /// <summary>
        ///  movePath
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public List<V3> movePath;
        /// <summary>
        ///  needMove
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public bool needMove;
        /// <summary>
        ///  targetID
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public string targetID;
        /// <summary>
        ///  currFireTimes
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int currFireTimes;
        /// <summary>
        ///  currAnimName
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public string currAnimName;
        /// <summary>
        ///  cdTime
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public float cdTime;
        /// <summary>
        ///  buffs
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public List<PVPBuff> buffs;
        /// <summary>
        ///  isSkillFiring
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public bool isSkillFiring;
        /// <summary>
        ///  armySkillCDTime
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public float armySkillCDTime;
        /// <summary>
        ///  bulletBuffID
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int bulletBuffID;
        /// <summary>
        ///  bulletAffectRadius
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public float bulletAffectRadius;
        /// <summary>
        ///  skillActionName
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public string skillActionName;
        /// <summary>
        ///  bulletEffectType
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public string bulletEffectType;
        /// <summary>
        ///  armySkillID
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public int armySkillID;
        /// <summary>
        ///  armySkillID
        /// </summary>
		[ProtoMember(22, IsRequired = false)]
		public float armySkillCD;
        /// <summary>
        ///  bulletHitEffectName
        /// </summary>
		[ProtoMember(23, IsRequired = false)]
		public string bulletHitEffectName;

	}
}