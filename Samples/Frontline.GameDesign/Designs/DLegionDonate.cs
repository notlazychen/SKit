using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DLegionDonate
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        public int cost { get; set; }
        public int exp_party { get; set; }
        public int party_contri { get; set; }
        public int party_coin { get; set; }        
        public int contri { get; set; }
        [MaxLength(64)]
        public string name { get; set; }
    }
}
