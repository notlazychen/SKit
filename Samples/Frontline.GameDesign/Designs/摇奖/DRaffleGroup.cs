using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DRaffleGroup
    {
        [Key]
        public int type { get; set; }//抽奖类型
        public int cost_item { get; set; }//消耗道具ID
        public int item_cnt_1 { get; set; }//单抽消耗数量
        public int item_cnt_10 { get; set; }//10连消耗数量
        public int first_drop { get; set; }//首抽掉落组
        public int normal_drop { get; set; }//单抽掉落组
        public int adv_drop { get; set; }//10连掉落组
        public int base_drop { get; set; }//保底掉落组
        public int nec_drop { get; set; }//10连必掉组
        public int base_numb { get; set; }//保底次数
        public DateTime? endtime { get; set; }//持续时间/秒
        public JsonObject<List<int>> theme_unit_id { get; set; }//
    }
}