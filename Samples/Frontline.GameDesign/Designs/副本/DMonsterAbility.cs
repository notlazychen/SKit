using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DMonsterAbility
    {
        [Key]
        public int level { get; set; }//怪物等级
        public float s_hp { get; set; }//士兵生命
        public float s_atk { get; set; }//士兵攻击
        public float s_def { get; set; }//士兵防御
        public float t_hp { get; set; }//坦克生命
        public float t_atk { get; set; }//坦克攻击
        public float t_def { get; set; }//坦克防御
    }
}