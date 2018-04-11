using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class LegionBBS
    {
        [Key]
        public string Id { get; set; }

        public string Content { get; set; }
        public string PlayerId { get; set; }
        public string LegionId { get; set; }
        public DateTime Time { get; set; }
    }
}
