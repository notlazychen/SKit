using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DOlReward
    {
        [Key]
        public int id { get; set; }
        public TimeSpan time { get; set; }
        public int t { get; set; }
        public JsonObject<int[]> low_id { get; set; }
        public JsonObject<int[]> low_cnt { get; set; }
        public JsonObject<int[]> adv_id { get; set; }
        public JsonObject<int[]> adv_cnt { get; set; }
    }
}