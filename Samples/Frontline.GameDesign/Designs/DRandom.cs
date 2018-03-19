using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DRandom
    {
        [Key]
        public int id { get; set; }
        [MaxLength(32)]
        public string desc { get; set; }
        public JsonObject<int[]> gid { get; set; }
        public JsonObject<int[]> count { get; set; }
        public JsonObject<int[]> res_type { get; set; }
        public JsonObject<int[]> res_count { get; set; }
        public JsonObject<int[]> weight { get; set; }
    }
}
