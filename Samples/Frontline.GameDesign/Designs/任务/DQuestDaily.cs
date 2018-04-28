using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DQuestDaily
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        //public string name{get;set;} 
        //public string desc{get;set;} 
        //public string icon{get;set;} 
        public JsonObject<int[]> level_area { get; set; }
        public int condition_type { get; set; }
        public int condition_target { get; set; }
        public int max_progress { get; set; }
        //public int jump_panel{get;set;} 
        public int res_exp { get; set; }
        public int reward_type { get; set; }
        public int reward_ID { get; set; }
        public int reward_num { get; set; }
        public int quest_point { get; set; }
    }
}
