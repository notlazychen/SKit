using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DFacTask
    {
        [Key]
        public int id { get; set; }
        //public string name { get; set; }
        public int group { get; set; }
        public int type { get; set; }
        public int star { get; set; }
        //public string desc { get; set; }
        public int cost_oil { get; set; }
        public int w { get; set; }
        public int worker_q { get; set; }
        public int cost_time { get; set; }//完成时间-秒
        public int res_type { get; set; }
        public int res_cnt { get; set; }
        public JsonObject<int[]> item_type { get; set; }
        public JsonObject<int[]> item_cnt { get; set; }
        public float reward_ex_prob { get; set; }
        public JsonObject<int[]> item_id_ex { get; set; }
        public JsonObject<int[]> item_cnt_ex { get; set; }
        public int done_item_id { get; set; }
        public int done_item_cnt { get; set; }
    }
}
