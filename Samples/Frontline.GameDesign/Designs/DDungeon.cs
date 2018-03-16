using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DDungeon
    {
        /// <summary>
        /// 关卡ID
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 副本分类
        /// </summary>
        [MaxLength(32)]
        public int type { get; set; }
        [MaxLength(32)]
        public String type_name { get; set; }// 副本分类名称
        public int section { get; set; }// 章节ID
        public int mission { get; set; }// 小节ID
        [MaxLength(32)]
        public String section_name { get; set; }// 章节名称
        [MaxLength(32)]
        public String name { get; set; }// 关卡名称
        [MaxLength(32)]
        public String desc { get; set; }// 关卡介绍
        [MaxLength(32)]
        public String icon { get; set; }// 关卡ICON
        [MaxLength(32)]
        public String screen_id { get; set; }// 场景ID
        public int level_limit { get; set; }// 进入玩家等级
        public int oil_cost { get; set; }// 消耗原油值
        public int fight_times { get; set; }// 每日挑战次数
        public int power { get; set; }// 推荐战力值
        public int exp { get; set; }// 玩家经验
        public int gold { get; set; }// 奖励金币
        public int random_id { get; set; }// 奖励的随机库ID
        public int time_limit_1 { get; set; }// 通关限制时间（秒）
        public int time_limit_2 { get; set; }// 2星通关时间（ 秒）
        public int time_limit_3 { get; set; }// 3星通关时间（秒）
        public int wipe_cost { get; set; }// 扫荡消耗扫荡点数
        public int next { get; set; }// 开启后置关卡
        [MaxLength(32)]
        public String map_res_name { get; set; }//地图资源文件名
        [MaxLength(32)]
        public String map_fighting { get; set; }//地图战斗信息资源名
        [MaxLength(32)]
        public String map_file_name { get; set; }//关卡文件名
        public int exp_element { get; set; }//获得兵种经验

        [MaxLength(128)]
        public string drop_items { get; set; }
        private List<int> _drop_items_real;
        [NotMapped]
        public List<int> dropItems
        {
            get
            {
                if(_drop_items_real == null)
                {
                    _drop_items_real = drop_items.Trim(new char[] { '[', ']'}).Split(",").Select(int.Parse).ToList();
                }
                return _drop_items_real;
            }
        }//战前可能掉落显示
    }
}