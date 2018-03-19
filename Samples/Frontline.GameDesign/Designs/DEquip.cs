using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DEquip
    {
        [Key]
        public int id { get; set; }
        [MaxLength(32)]
        public string name { get; set; }
        [MaxLength(64)]
        public string desc { get; set; }
        public int type { get; set; }
        public int pos { get; set; }
        public int grade { get; set; }
        [MaxLength(64)]
        public string icon { get; set; }
        public int base_attr_type { get; set; }
        public int player_lv { get; set; }
        public int base_attr_value { get; set; }
        public int level_grow { get; set; }
        public int level_k { get; set; }
        public int max_level { get; set; }
        public JsonObject<int[]> grade_item_id { get; set; }
        public JsonObject<int[]> grade_item_cnt { get; set; }
        public int grade_grow { get; set; }
        public int next_id { get; set; }
    }
}
