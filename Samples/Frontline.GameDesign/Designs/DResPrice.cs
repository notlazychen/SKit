using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DResPrice
    {
        [Key]
        public int times { get; set; }
        public int oil_cost { get; set; }
        public int oil { get; set; }
        public int gold_cost { get; set; }
        public int gold { get; set; }
        public int supply_cost { get; set; }
        public int supply { get; set; }
        public int iron_cost { get; set; }
        public int iron { get; set; }
    }
}
