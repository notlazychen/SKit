using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DDiKangQianXian
    {
        [Key]
        public int wid { get; set; }
        public int dungeon_id { get; set; }
        public int token { get; set; }
        public int command { get; set; }
    }
}
