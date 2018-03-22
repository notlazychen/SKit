using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DEquip
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        public int pos { get; set; }
        public int base_attr_type { get; set; }
        public int base_attr_value { get; set; }
        public int level_grow { get; set; }
        public int level_k { get; set; }
        public int gradeid { get; set; }
    }
}
