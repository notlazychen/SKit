using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DLegion
    {
        [Key]
        public int level { get; set; }
        public int exp { get; set; }
        public int max { get; set; }
        public float glv_add { get; set; }
        public int def_player_cnt { get; set; }
    }
}
