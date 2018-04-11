using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DRandom
    {
        [Key]
        public int id { get; set; }
        public int random { get; set; }
        public int group { get; set; }
        public int w { get; set; }
        public int type { get; set; }
        public int tid { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}
