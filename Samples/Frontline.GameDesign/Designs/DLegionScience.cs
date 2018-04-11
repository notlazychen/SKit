using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DLegionScience
    {
        public int id { get; set; }
        public int lv { get; set; }
        [MaxLength(64)]
        public string name { get; set; }
        [MaxLength(64)]
        public string desc { get; set; }
        public JsonObject<int[]> unit_scope { get; set; }
        public int hp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int damage { get; set; }
        public int damage_del { get; set; }
        public int icon { get; set; }
        public int legion_lv { get; set; }
        public JsonObject<int[]> res_type { get; set; }
        public JsonObject<int[]> res_cnt { get; set; }
        public JsonObject<int[]> item_id { get; set; }
        public JsonObject<int[]> item_cnt { get; set; }
    }
}
