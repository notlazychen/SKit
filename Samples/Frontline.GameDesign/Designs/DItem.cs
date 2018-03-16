using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DItem
    {
        [Key]
        public int tid { get; set; } // 物品ID
        [MaxLength(32)]
        public string name { get; set; } // 名称
        public int type{ get; set; }// 道具类型
        public int bag_type{ get; set; }// 背包类型
        public int quality{ get; set; }// 道具品质
        public int icon{ get; set; }// Icon_Id
        public bool useable{ get; set; }// 能否主动使用
        public int breakCount{ get; set; }// 使用后获得的数量
        public int breakRandomId{ get; set; }// 使用后对应的随机库ID
        public int breakUnitId{ get; set; }// 使用后获得的兵种ID
       
        public int price{ get; set; }// 出售获得金币（0=不能出售）
        public int overlap{ get; set; }// 最大叠加数量       
        public TimeSpan? cd{ get; set; }
        public int diamond{ get; set; }
        public int worth{ get; set; }
        [MaxLength(64)]
        public String desc { get; set; }// 道具描述
    }
}