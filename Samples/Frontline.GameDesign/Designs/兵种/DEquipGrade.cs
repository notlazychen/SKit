using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DEquipGrade
    {
        [Key]
        public int id { get; set; }
        public int grade { get; set; }
        public int max_level { get; set; }
        public JsonObject<int[]> grade_item_id { get; set; }
        public JsonObject<int[]> grade_item_cnt { get; set; }
        public float grade_grow { get; set; }
        public int next_id { get; set; }
    }
}
