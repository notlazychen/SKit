using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DDiKangQianXianBox
    {
        [Key]
        public int id { get; set; }
        public int box { get; set; }
        public int wid { get; set; }
    }
}
