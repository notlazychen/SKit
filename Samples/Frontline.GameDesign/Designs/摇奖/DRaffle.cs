using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DRaffle
    {
        [Key]
        public int id { get; set; }
        public int drop { get; set; }
        public int item_id { get; set; }
        public int star { get; set; }
        public int w_0 { get; set; }
        public int w_1 { get; set; }
        public int w_2 { get; set; }
        public int item_cnt_min { get; set; }
        public int item_cnt_max { get; set; }
        public bool special { get; set; }
    }
}