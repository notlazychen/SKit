using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PartyScienceInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  是否开启
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool open;
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  ICON
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int icon;
        /// <summary>
        ///  科技描述
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  适用类型
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<int> scope;
        /// <summary>
        ///  生命加成
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public float hp_add;
        /// <summary>
        ///  火力加成
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public float att_add;
        /// <summary>
        ///  防御加成
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public float def_add;
        /// <summary>
        ///  暴击率
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public float crit;
        /// <summary>
        ///  暴击伤害
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public float crit_hurt;
        /// <summary>
        ///  伤害加成
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public float hurt_add;
        /// <summary>
        ///  伤害减免
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public float hurt_sub;
        /// <summary>
        ///  移动速度
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public float speed;
        /// <summary>
        ///  主线副本金币产量提升
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public float gold_main;
        /// <summary>
        ///  建筑升级时间减少
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public float building_time;
        /// <summary>
        ///  造兵时间减少
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public float unit_time;
        /// <summary>
        ///  抵抗前线金币产量提升
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public float gold_resist;
        /// <summary>
        ///  军需容量提升
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public float supply_max;
        /// <summary>
        ///  钢铁容量提升
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public float iron_max;
        /// <summary>
        ///  军团等级需求
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public int party_level;

	}
}