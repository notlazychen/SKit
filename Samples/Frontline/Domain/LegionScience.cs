using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class LegionScience
    {
        [Key]
        public string Id { get; set; }

        public string PlayerId { get; set; }
        public int Tid { get; set; }
        public int Level { get; set; }
    }
}
