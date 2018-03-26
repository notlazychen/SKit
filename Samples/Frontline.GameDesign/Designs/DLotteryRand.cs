using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DLotteryRand
    {
        [Key]
        public int id { get; set; }
        public int group { get; set; }
        public int item_id { get; set; }
        public int item_cnt { get; set; }
        public int w { get; set; }
        public int lv_min { get; set; }
        public int lv_max { get; set; }
    }
}