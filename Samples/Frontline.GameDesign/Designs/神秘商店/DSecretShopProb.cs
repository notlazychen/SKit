using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DSecretShopProb
    {
        [Key]
        public int mission_type { get; set; }
        [MaxLength(32)]
        public string desc { get; set; }
        public int prob { get; set; }
    }
}