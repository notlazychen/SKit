using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class FBInfo
	{
        /// <summary>
        ///  关卡ID（数据库id）
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string fid;
        /// <summary>
        ///  关卡ID(策划id)
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int id;
        /// <summary>
        ///  是否已经打开
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool open;
        /// <summary>
        ///  历史最高战绩（星级）
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int star;
        /// <summary>
        ///  今日剩余挑战次数（-1表示无限次数）
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int remainTimes;
        /// <summary>
        ///  今日剩余可购买次数(废弃)
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int remainBuyTimes;
        /// <summary>
        ///  副本分类
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int type;
        /// <summary>
        ///  关卡名称
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string name;
        /// <summary>
        ///  关卡介绍
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  关卡ICON
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  场景ID
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public string screen_id;
        /// <summary>
        ///  进入玩家等级
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int level_limit;
        /// <summary>
        ///  消耗原油值
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int oil_cost;
        /// <summary>
        ///  每日挑战次数
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int fight_times;
        /// <summary>
        ///  推荐战力值
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int power;
        /// <summary>
        ///  奖励经验
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  奖励金币
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  奖励的随机库ID
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int random_id;
        /// <summary>
        ///  通关限制时间（秒）
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public int time_limit_1;
        /// <summary>
        ///  2星通关时间（ 秒）
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public int time_limit_2;
        /// <summary>
        ///  3星通关时间（秒）
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public int time_limit_3;
        /// <summary>
        ///  扫荡消耗扫荡点数
        /// </summary>
		[ProtoMember(22, IsRequired = false)]
		public int wipe_cost;
        /// <summary>
        ///  地图资源文件名
        /// </summary>
		[ProtoMember(23, IsRequired = false)]
		public string map_res_name;
        /// <summary>
        ///  地图战斗信息资源名
        /// </summary>
		[ProtoMember(24, IsRequired = false)]
		public string map_fighting;
        /// <summary>
        ///  关卡文件名
        /// </summary>
		[ProtoMember(25, IsRequired = false)]
		public string map_file_name;
        /// <summary>
        ///  战前可能掉落显示
        /// </summary>
		[ProtoMember(26, IsRequired = false)]
		public List<int> dropItems;
        /// <summary>
        ///  剩余重置次数
        /// </summary>
		[ProtoMember(27, IsRequired = false)]
		public int resetRemainNumb;

	}
}