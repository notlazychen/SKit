using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DLottery
    {
        [Key]
        public int id { get; set; }
        [MaxLength(32)]
        public String name { get; set; }
        public int free_cnt { get; set; }
        public int free_cd { get; set; }
        public int cost_item { get; set; }
        public int cost_res_type { get; set; }
        public int cost_res_cnt { get; set; }
        public int ten_discount { get; set; }
        public int rand { get; set; }
        public int rand_sp { get; set; }
        public int rand_first10 { get; set; }
    }
}