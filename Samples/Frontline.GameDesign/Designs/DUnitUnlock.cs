using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DUnitUnlock
    {
        [Key]
        public int tid { get; set; }
        public int item_id { get; set; }
        public int item_cnt { get; set; }
    }
}
