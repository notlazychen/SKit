using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DQuest
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        //public string name{get;set;} 
        //public string desc{get;set;} 
        //public string icon{get;set;} 
        public int limit_level { get; set; }
        public int next_quest_id { get; set; }
        public int condition_type { get; set; }
        public int condition_target { get; set; }
        public int max_progress { get; set; }
        //public int jump_panel{get;set;} 
        //public int res_exp { get; set; }
        //public int res_gold { get; set; }
        public int res_diamond { get; set; }
        //public int res_supply { get; set; }
        //public int res_iron { get; set; }
        //public int res_oil { get; set; }
        //public JsonObject<int[]> items_id { get; set; }
        //public JsonObject<int[]> items_cnt { get; set; }
        public int index { get; set; }

    }
}
