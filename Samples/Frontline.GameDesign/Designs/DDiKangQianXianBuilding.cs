using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DDiKangQianXianBuilding
    {
        [Key]
        public int id { get; set; }
        public int hp { get; set; }
        public int defence { get; set; }
    }
}
