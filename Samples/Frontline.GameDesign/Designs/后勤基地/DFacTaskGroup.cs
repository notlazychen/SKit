using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DFacTaskGroup
    {
        [Key]
        public int id { get; set; }
        public int gourp_supply { get; set; }
        public int group_iron { get; set; }
        public int min_level { get; set; }
        public int max_level { get; set; }
    }
}
