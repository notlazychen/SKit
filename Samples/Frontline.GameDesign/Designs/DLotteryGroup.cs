using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DLotteryGroup
    {
        [Key]
        public int id { get; set; }
        public JsonObject<int[]> group { get; set; }
        public JsonObject<int[]> group_w { get; set; }
    }
}