using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DSecretShopItem
    {
        [Key]
        public int id { get; set; }
        public int w { get; set; }
        public int group { get; set; }
        public int res_type { get; set; }
        public int old_price { get; set; }
        public int cur_price { get; set; }
        public int item_id { get; set; }
        public int item_cnt { get; set; }
        public int limit_cnt { get; set; }
        public int vip { get; set; }
    }
}