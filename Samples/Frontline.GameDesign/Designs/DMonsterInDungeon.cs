using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DMonsterInDungeon
    {
        public int dungeon_id { get; set; } //关卡ID
        public int mid { get; set; } //怪物ID
        //public string desc { get; set; } //关卡
        public int level { get; set; }//怪物等级
    }
}