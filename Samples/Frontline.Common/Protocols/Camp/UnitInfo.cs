using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class UnitInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  数量,<0表示未解锁
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int number;
        /// <summary>
        ///  兵种ID
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int tid;
        /// <summary>
        ///  兵种当前熟练度
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int level;
        /// <summary>
        ///  阶
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int claz;
        /// <summary>
        ///  兵种名称
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string name;
        /// <summary>
        ///  类型
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int type;
        /// <summary>
        ///  国籍
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int nation;
        /// <summary>
        ///  描述说明
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  星级
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int star;
        /// <summary>
        ///  基础生命
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int hp;
        /// <summary>
        ///  基础火力
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int att;
        /// <summary>
        ///  基础防御
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int defence;
        /// <summary>
        ///  基础暴击率
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public float crit;
        /// <summary>
        ///  基础暴击伤害
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public float crit_hurt;
        /// <summary>
        ///  伤害加成%
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public float hurt_add;
        /// <summary>
        ///  伤害减免%
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public float hurt_sub;
        /// <summary>
        ///  暴击值
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public int crit_v;
        /// <summary>
        ///  伤害加成值
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public int hurt_add_v;
        /// <summary>
        ///  伤害减免值
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public int hurt_sub_v;
        /// <summary>
        ///  护甲
        /// </summary>
		[ProtoMember(22, IsRequired = false)]
		public int armor;
        /// <summary>
        ///  穿透力（伤害系数）
        /// </summary>
		[ProtoMember(23, IsRequired = false)]
		public float hurt_multiple;
        /// <summary>
        ///  装弹时间（秒）
        /// </summary>
		[ProtoMember(24, IsRequired = false)]
		public float cd;
        /// <summary>
        ///  攻击距离（m)
        /// </summary>
		[ProtoMember(25, IsRequired = false)]
		public float distance;
        /// <summary>
        ///  杀伤半径（m)
        /// </summary>
		[ProtoMember(26, IsRequired = false)]
		public float r;
        /// <summary>
        ///  攻击偏移
        /// </summary>
		[ProtoMember(27, IsRequired = false)]
		public float off;
        /// <summary>
        ///  炮塔转速
        /// </summary>
		[ProtoMember(28, IsRequired = false)]
		public float rev;
        /// <summary>
        ///  转弯速度
        /// </summary>
		[ProtoMember(29, IsRequired = false)]
		public float rev_body;
        /// <summary>
        ///  移动速度
        /// </summary>
		[ProtoMember(30, IsRequired = false)]
		public float speed;
        /// <summary>
        ///  机动性
        /// </summary>
		[ProtoMember(31, IsRequired = false)]
		public int mob;
        /// <summary>
        ///  生命加成%
        /// </summary>
		[ProtoMember(32, IsRequired = false)]
		public float hp_add;
        /// <summary>
        ///  攻击加成%
        /// </summary>
		[ProtoMember(33, IsRequired = false)]
		public float att_add;
        /// <summary>
        ///  防御加成%
        /// </summary>
		[ProtoMember(34, IsRequired = false)]
		public float def_add;
        /// <summary>
        ///  基础生命成长
        /// </summary>
		[ProtoMember(35, IsRequired = false)]
		public float hp_growth;
        /// <summary>
        ///  基础火力成长
        /// </summary>
		[ProtoMember(36, IsRequired = false)]
		public float att_growth;
        /// <summary>
        ///  基础防御成长
        /// </summary>
		[ProtoMember(37, IsRequired = false)]
		public float defence_growth;
        /// <summary>
        ///  兵种细分类型
        /// </summary>
		[ProtoMember(38, IsRequired = false)]
		public int type_detail;
        /// <summary>
        ///  激活需玩家等级
        /// </summary>
		[ProtoMember(39, IsRequired = false)]
		public int levelLimit;
        /// <summary>
        ///  获得途径
        /// </summary>
		[ProtoMember(40, IsRequired = false)]
		public string gain;
        /// <summary>
        ///  兵种单位（小队）数量
        /// </summary>
		[ProtoMember(41, IsRequired = false)]
		public int count;
        /// <summary>
        ///  单次攻击持续时间（秒）
        /// </summary>
		[ProtoMember(42, IsRequired = false)]
		public float last_time;
        /// <summary>
        ///  单次扫出子弹数
        /// </summary>
		[ProtoMember(43, IsRequired = false)]
		public int bullet_count;
        /// <summary>
        ///  所属的player的id
        /// </summary>
		[ProtoMember(44, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  军衔
        /// </summary>
		[ProtoMember(45, IsRequired = false)]
		public int rank;
        /// <summary>
        ///  兵种存在性
        /// </summary>
		[ProtoMember(46, IsRequired = false)]
		public int exist;
        /// <summary>
        ///  造兵所需能量点
        /// </summary>
		[ProtoMember(47, IsRequired = false)]
		public int energy;
        /// <summary>
        ///  休整消耗金币
        /// </summary>
		[ProtoMember(48, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  休整消耗军需
        /// </summary>
		[ProtoMember(49, IsRequired = false)]
		public int supply;
        /// <summary>
        ///  休整消耗钢铁
        /// </summary>
		[ProtoMember(50, IsRequired = false)]
		public int iron;
        /// <summary>
        ///  实时对战点数
        /// </summary>
		[ProtoMember(51, IsRequired = false)]
		public int pvp_point;
        /// <summary>
        ///  实时对战死亡后扣分数
        /// </summary>
		[ProtoMember(52, IsRequired = false)]
		public int pvp_dec_score;
        /// <summary>
        ///  耐久度上限
        /// </summary>
		[ProtoMember(53, IsRequired = false)]
		public int max_energy;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(54, IsRequired = false)]
		public int power;
        /// <summary>
        ///  装备列表
        /// </summary>
		[ProtoMember(55, IsRequired = false)]
		public List<EquipInfo> equips;
        /// <summary>
        ///  是否在休整中
        /// </summary>
		[ProtoMember(56, IsRequired = false)]
		public bool preparing;
        /// <summary>
        ///  休整结束时间
        /// </summary>
		[ProtoMember(57, IsRequired = false)]
		public long prepareEndTime;
        /// <summary>
        ///  兵种技能
        /// </summary>
		[ProtoMember(58, IsRequired = false)]
        public List<SkillInfo> unitSkills;
        //[ProtoMember(58, IsRequired = false)]
        //public List<int> unitSkills;
        /// <summary>
        ///  生命加成值
        /// </summary>
		[ProtoMember(59, IsRequired = false)]
		public int hp_ex;
        /// <summary>
        ///  火力加成值
        /// </summary>
		[ProtoMember(60, IsRequired = false)]
		public int att_ex;
        /// <summary>
        ///  防御加成值
        /// </summary>
		[ProtoMember(61, IsRequired = false)]
		public int def_ex;

	}
}