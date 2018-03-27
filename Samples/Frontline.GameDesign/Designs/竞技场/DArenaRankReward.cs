using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DArenaRankReward
    {
        [Key]
        public int id { get; set; }
        public JsonObject<int[]> rank_area { get; set; }
        public int random_id { get; set; }
        public JsonObject<int[]> items_id { get; set; }
        public JsonObject<int[]> items_cnt { get; set; }
    }
}
