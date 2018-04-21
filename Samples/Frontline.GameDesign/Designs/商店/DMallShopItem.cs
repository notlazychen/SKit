using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DMallShopItem
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        [MaxLength(64)]
        public string desc { get; set; }
        public int item_id { get; set; }
        public int count { get; set; }
        public int res_type { get; set; }
        public int res_cnt { get; set; }
        public int rate { get; set; }
    }
}