using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DWeekBattle
    {
        public int mid { get; set; }
        public int lv { get; set; }
        public int day { get; set; }
        public JsonObject<int[]> unit_type { get; set; }
        public JsonObject<int[]> res_type { get; set; }
        public JsonObject<int[]> res_cnt { get; set; }
        public JsonObject<int[]> item_id { get; set; }
        public JsonObject<int[]> item_cnt { get; set; }
    }
}
