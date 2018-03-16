using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DMonster
    {
        [Key]
        public int id { get; set; }                               //怪物ID
        [MaxLength(32)]
        public string name { get; set; }                          //怪物名称
        public int type { get; set; }                             //类型
        public int type_detail { get; set; }                      //兵种细分类型
        public int nation { get; set; }                           //国籍
        [MaxLength(64)]
        public string desc { get; set; }                          //备注说明
        public int lv { get; set; }                               //怪物等级
        public int armor { get; set; }                            //护甲类型
        public int hp { get; set; }                               //生命加成%
        public int att { get; set; }                              //攻击加成%
        public int defence { get; set; }                          //防御加成%
        public float crit { get; set; }                           //暴击率
        public float crit_hurt { get; set; }                      //暴击伤害
        public float hurt_add { get; set; }                       //伤害加成
        public float hurt_sub { get; set; }                       //伤害减免
        public float hurt_multiple { get; set; }                  //穿透力（伤害系数）
        public float cd { get; set; }                             //装弹时间（秒）
        public float distance { get; set; }                       //攻击距离（m)	
        public float r { get; set; }                              //杀伤半径（m)
        public float off { get; set; }                            //攻击偏移（命中）
        public float rev { get; set; }                            //炮塔转速
        public float rev_body { get; set; }                       //转弯速度
        public float speed { get; set; }                          //移动速度
        public int count { get; set; }                            //兵种单位（小队）数量 	
        public float last_time { get; set; }                      //单次攻击持续时间（秒）
        public int bullet_count { get; set; }                     //单次扫出子弹数
        [MaxLength(32)]
        public string model { get; set; }                         //怪物模型
        public float scale { get; set; }                          //模型缩放比例
        [MaxLength(32)]
        public string att_effect { get; set; }                    //攻击音效
        [MaxLength(32)]
        public string move_effect { get; set; }                   //移动音效
        [MaxLength(32)]
        public string die_model { get; set; }                     //死亡后模型名
        public int energy { get; set; }                           //获得能量点
    }
}