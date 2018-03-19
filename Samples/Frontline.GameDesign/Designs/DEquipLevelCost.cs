using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DEquipLevelCost
    {
        [Key]
        public int level { get; set; }
        public int tank_gold { get; set; }
        public int soldier_gold { get; set; }
    }
}
