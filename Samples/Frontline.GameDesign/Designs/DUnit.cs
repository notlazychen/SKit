using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DUnit
    {
        [Key]
        public int tid { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public int nation { get; set; }
        public int star { get; set; }
        public JsonObject<int[]> prop_type { get; set; }
        public JsonObject<int[]> prop_val { get; set; }
        public float crit { get; set; }
        public float crit_hurt { get; set; }
        public float hurt_add { get; set; }
        public float hurt_sub { get; set; }
        public int crit_v { get; set; }
        public int hurt_add_v { get; set; }
        public int hurt_sub_v { get; set; }
        public int armor { get; set; }
        public float hurt_multiple { get; set; }
        public float cd { get; set; }
        public float distance { get; set; }
        public float r { get; set; }
        public float off { get; set; }
        public float rev { get; set; }
        public float rev_body { get; set; }
        public float speed { get; set; }
        public int mob { get; set; }
        public float hp_add { get; set; }
        public float att_add { get; set; }
        public float def_add { get; set; }
        public JsonObject<int[]> prop_grow_type { get; set; }
        public JsonObject<int[]> prop_grow_val { get; set; }
        public int type_detail { get; set; }
        public int count { get; set; }
        public float last_time { get; set; }
        public int bullet_count { get; set; }
        public int energy { get; set; }
        public int exist { get; set; }
        public int max_energy { get; set; }
        [MaxLength(128)]
        public string desc { get; set; }
        public int pvp_point { get; set; }
        public int pvp_dec_score { get; set; }
        public JsonObject<int[]> res_type { get; set; }
        public JsonObject<int[]> res_cnt { get; set; }
        public int sec { get; set; }
        public int show_p { get; set; }
        public string gvg_rest_res_cnt { get; set; }
        public int gvg_rest_second { get; set; }
        public int gvg_rest_diamond { get; set; }
        public JsonObject<int[]> equip { get; set; }
        public int ww_type { get; set; }
        public int grade_item_id { get; set; }
        public int grade_max { get; set; }
        public JsonObject<List<int>> skills { get; set; }
    }
}
