using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DSecretShop
    {
        [Key]
        public int id { get; set; }
        public int mission_type { get; set; }
        public int shop_id { get; set; }
        public JsonObject<int[]> trigger_lv { get; set; }
        public int prob { get; set; }
        public int interval_second { get; set; }
        public int duration_second { get; set; }
    }
}