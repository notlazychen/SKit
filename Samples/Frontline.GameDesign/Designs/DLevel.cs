using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DLevel
    {
        [Key]
        public int level { get; set; }
        public int exp { get; set; }
        public int buy_gold { get; set; }
    }
}
