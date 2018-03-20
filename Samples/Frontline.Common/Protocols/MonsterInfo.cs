using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MonsterInfo
	{
        /// <summary>
        ///  怪物ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  怪物名称
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string name;
        /// <summary>
        ///  怪物等级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  类型
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
        /// <summary>
        ///  兵种细分类型
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int type_detail;
        /// <summary>
        ///  国籍（1德国2苏联3美国4英国5中国6日本）
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int nation;
        /// <summary>
        ///  备注说明
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  生命
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int hp;
        /// <summary>
        ///  火力
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int att;
        /// <summary>
        ///  防御
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int defence;
        /// <summary>
        ///  暴击率
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public float crit;
        /// <summary>
        ///  暴击伤害
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public float crit_hurt;
        /// <summary>
        ///  伤害加成%
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public float hurt_add;
        /// <summary>
        ///  伤害减免%
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public float hurt_sub;
        /// <summary>
        ///  暴击值
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int crit_v;
        /// <summary>
        ///  伤害加成值
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int hurt_add_v;
        /// <summary>
        ///  伤害减免值
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int hurt_sub_v;
        /// <summary>
        ///  护甲
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int armor;
        /// <summary>
        ///  穿透力（伤害系数）
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public float hurt_multiple;
        /// <summary>
        ///  装弹时间（秒）
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public float cd;
        /// <summary>
        ///  攻击距离（m)
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public float distance;
        /// <summary>
        ///  杀伤半径（m)
        /// </summary>
		[ProtoMember(22, IsRequired = false)]
		public float r;
        /// <summary>
        ///  攻击偏移
        /// </summary>
		[ProtoMember(23, IsRequired = false)]
		public float off;
        /// <summary>
        ///  炮塔转速
        /// </summary>
		[ProtoMember(24, IsRequired = false)]
		public float rev;
        /// <summary>
        ///  转弯速度
        /// </summary>
		[ProtoMember(25, IsRequired = false)]
		public float rev_body;
        /// <summary>
        ///  移动速度
        /// </summary>
		[ProtoMember(26, IsRequired = false)]
		public float speed;
        /// <summary>
        ///  兵种单位（小队）数量
        /// </summary>
		[ProtoMember(27, IsRequired = false)]
		public int count;
        /// <summary>
        ///  单次攻击持续时间（秒）
        /// </summary>
		[ProtoMember(28, IsRequired = false)]
		public float last_time;
        /// <summary>
        ///  单次扫出子弹数
        /// </summary>
		[ProtoMember(29, IsRequired = false)]
		public int bullet_count;
        /// <summary>
        ///  怪物模型
        /// </summary>
		[ProtoMember(30, IsRequired = false)]
		public string model;
        /// <summary>
        ///  模型缩放比例
        /// </summary>
		[ProtoMember(31, IsRequired = false)]
		public float scale;
        /// <summary>
        ///  攻击音效
        /// </summary>
		[ProtoMember(32, IsRequired = false)]
		public string att_effect;
        /// <summary>
        ///  移动音效
        /// </summary>
		[ProtoMember(33, IsRequired = false)]
		public string move_effect;
        /// <summary>
        ///  死亡后模型名
        /// </summary>
		[ProtoMember(34, IsRequired = false)]
		public string die_model;
        /// <summary>
        ///  获得能量点
        /// </summary>
		[ProtoMember(35, IsRequired = false)]
		public int energy;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(36, IsRequired = false)]
		public int power;
        /// <summary>
        ///  兵种技能
        /// </summary>
		[ProtoMember(37, IsRequired = false)]
		public List<int> unitSkills;

	}
}