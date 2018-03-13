using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ArmyOperate
	{
        /// <summary>
        ///  operateType
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int operateType;
        /// <summary>
        ///  hurtType
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int hurtType;
        /// <summary>
        ///  armyID
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string armyID;
        /// <summary>
        ///  armyServerID
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string armyServerID;
        /// <summary>
        ///  armyPos
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public V3 armyPos;
        /// <summary>
        ///  moveTargetPos
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public V3 moveTargetPos;
        /// <summary>
        ///  moveTargetPosList
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<V3> moveTargetPosList;
        /// <summary>
        ///  armyQuat
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public Quaternion armyQuat;
        /// <summary>
        ///  坦克的大炮朝向
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public Quaternion tankGunBarrelQuat;
        /// <summary>
        ///  targetID
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public string targetID;
        /// <summary>
        ///  groupIdList
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public List<string> groupIdList;
        /// <summary>
        ///  targetServerID
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public string targetServerID;
        /// <summary>
        ///  animName
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public string animName;
        /// <summary>
        ///  hurtNumber
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int hurtNumber;
        /// <summary>
        ///  isBaoji
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public bool isBaoji;
        /// <summary>
        ///  技能模板Id
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int skillTID;
        /// <summary>
        ///  技能释放位置
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public V3 skillPos;
        /// <summary>
        ///  buffId
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int buffId;
        /// <summary>
        ///  isSkillAttack
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public bool isSkillAttack;

	}
}