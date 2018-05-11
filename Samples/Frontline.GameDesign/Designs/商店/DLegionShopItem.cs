using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DLegionShopItem
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        public int item_id { get; set; }
        public int item_cnt { get; set; }
        public int commodity_stock { get; set; }
        public int cost_res_type { get; set; }
        public int cost_res_cnt { get; set; }

        public int level_min { get; set; }
        public int order { get; set; }
    }
}